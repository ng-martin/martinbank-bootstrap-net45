MartinBank.Payment = function (options) {
    $.extend(this, options);
    this.frmChequeDetails = $('#frmChequeDetails');
    this.chequePayTo = this.frmChequeDetails.find('#PayTo');
    this.chequeDate = this.frmChequeDetails.find('#DateAsString');
    this.chequeAmount = this.frmChequeDetails.find('#Amount');
    this.chequeAmountInWords = this.frmChequeDetails.find('#AmountInWords');
    this.chequeESignature = this.frmChequeDetails.find('#ESignature');
    this.btnSend = this.frmChequeDetails.find('.btnSend');
};

MartinBank.Payment.prototype = {

    init: function() {
        this.bindEvents();
    },

    bindEvents: function () {
        // Date
        var self = this;
        self.chequeDate.prop({ placeholder: 'dd/mm/yyyy' });
        self.chequeDate.mask('00/00/0000');
        self.chequeDate.datepicker({ dateFormat: "dd/mm/yy" });
        self.chequeAmount.val('');
        self.chequeAmount.on('focusout', function() {
            if ($(this).val() === '') {
                self.chequeAmountInWords.val('');
                self.chequeESignature.val('');
            }
        });
        self.chequeAmount.mask('#,##0.00',
        {
            reverse: true,
            placeholder: '$0.00',
            onComplete: function(num) {
                var numbers = num.split(".");
                if (numbers.length === 1) {
                    num += '.00';
                } else if (numbers.length === 2) {
                    if (numbers[1].length === 1) {
                        num += '0';
                    }
                }
                self.chequeAmount.val(num);
            }
        });

        self.btnSend.on('click', function () {
            var result = self.validate();
            if (!result.isValid) {
                toastr.error(result.errors.join("<br />"), 'Needs your attention:');
                return;
            }
            var dataObj = self.frmChequeDetails.serializeObject();
            $.ajax({
                url: '/ChequeGenerator/ConvertAmountInWords',
                type: 'post',
                data: dataObj,
                success: function(response, status, jqXHR) {
                    if (response.success) {
                        self.chequeAmountInWords.val(response.words);
                        self.chequeESignature.val(response.esignature);
                    } else {
                        toastr.error(response.err, 'Error');
                    }
                },
                error: function (err) {
                    toastr.error('Ohh ohh...something wrong happen!', 'Error');
                },
                complete: function() {
                }
            });
        });
    },

    validate: function() {
        var errors = [];
        if ($.trim(this.chequePayTo.val()) === '') {
            errors.push('Pay-To field cannot be blank');
        }
        if ($.trim(this.chequeDate.val()) === '') {
            errors.push('Date field cannot be blank');
        }
        if ($.trim(this.chequeAmount.val()) === '') {
            errors.push('Amount field cannot be blank');
        }
        return { isValid: (errors.length < 1), errors: errors };
    }
};

$.fn.serializeObject = function () {
    var o = {};
    var a = this.serializeArray();
    $.each(a, function () {
        if (o[this.name]) {
            if (!o[this.name].push) {
                o[this.name] = [o[this.name]];
            }
            o[this.name].push(this.value || '');
        } else {
            o[this.name] = this.value || '';
        }
    });
    return o;
};