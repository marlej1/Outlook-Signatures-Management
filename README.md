# Outlook-Signatures-Management

My biggest project so far.

ASP.NET MVC application with JQuery, Ajax, Bootstrap and Entity Framework.

Application is a tool for managing singatures in a company.  It implements CRUD operations for Employee, Signature and Campaign models.
You can create your own signature or a campaign with an embedded HTML editor. 

A signature can be set to a default for the whole organization. There can only be one default signature for all employees at the same time. 
You can also assing the signature from the level of a single employee. Second option overrides the default implementation.

There is also a preview option where a user can see how the craeted signature would look like when filled with the data of the employee selected
from a dropdown list. To the signature a user can add some fields like first name, last name, email address. After going to preview mode those fields are replaced with the data of the selectend employee.

Campaigns can have their lifetime. All campaigns that are currently running are visble then in the preview mode
underneath the selected signature.



