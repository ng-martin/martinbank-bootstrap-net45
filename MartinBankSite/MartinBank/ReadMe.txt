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

* Injecting a LoggingService so that any error/info is saved on file (assumption: system read/writes to file within FileLoggingRepository class)

* This application does not persist data.

* MartinBank.Core library contains the main ChequeConverter utility class

* MartinBank.Entity library contains all entities used in the application. ie. Cheque entity.

* MartinBank.Tests library. Used for adding different unit tests within different areas in the application. I could've cerated separate Test libraries --
  per DLL ie: MartinBank.Core.Tests, but just wanted to keep it simply.	


* JS/CSS extras:
	** Use of bootstrap for quick interface design/style
	** toastr for displaying messages
	** jquery.mask for restricting specific user input and available for dates and money.
	** MartinBank JS available in: Scripts > MartinBank folder.