MartinBank - Cheque:
==================
Objective:
This application performs numbers to words conversion and present them in the form of a bank cheque.
>> (e.g. $123.10) and words (e.g. One hundred and twenty three dollars and ten cents)
** Practise the use of bootstrap for making site responsive

Notes:
==================

[Notes/Assumptions]:
* Based on .NET framework 4.5
* Authorization and authentication is not in place due to basic implementation.
* Assume there is a LogginService as well as ChequePaymentService so that information is store on file or database.
* This application does not persist data.
* MartinBank.Core library contains the main ChequeConverter class
* MartinBank.Entity library contains all entities used in the application. ie. Cheque entity.
* JS/CSS extras:
** Use of bootstrap for quick interface design/style
** toastr for displaying messages
** jquery.mask for restricting specific user input and available for dates and money.
** MartinBank JS available in: Scripts > MartinBank folder.