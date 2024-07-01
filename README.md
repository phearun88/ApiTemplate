# EnterpriseWebAPITemplate
Based on my experience,
I have done some research about how to implement a clean, single responsibility and maintainability code.
In the template, I have divided the folder:
- <b>Controller Layer</b>
- <b>Data Access Layer</b> main classes
  +  <i>DaoFactories</i> class to Get a provider specific (i.e. database specific) factory
  +  <i>DataAccessObjects</i> This class shields the client from the details of database specific data- 
  access objects. It returns the appropriate data-access objects according to the configuration.
  + <i>ValidatorRule</i> abstract class is to maintain property name to which rule applies and validation 
  error message.
