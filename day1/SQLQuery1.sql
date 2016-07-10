select FirstName, LastName, PhoneNumber, Name from Person.Person
inner join Person.PersonPhone on Person.Person.BusinessEntityID = Person.PersonPhone.BusinessEntityID
inner join Person.PhoneNumberType on Person.PersonPhone.PhoneNumberTypeID = Person.PhoneNumberType.PhoneNumberTypeID
where PersonType = 'EM'

select ProductID, Product.Name, ProductNumber, ProductCategory.Name, ProductSubcategory.Name from Production.Product
left join Production.ProductSubcategory on Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID
left join Production.ProductCategory on Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID

select Product.ProductID, Product.Name, ProductNumber, ProductModel.Name, DocumentNode from Production.Product
right join Production.ProductModel on Production.Product.ProductModelID = Production.ProductModel.ProductModelID
left join Production.ProductDocument on Production.Product.ProductID = Production.ProductDocument.ProductID

CREATE PROCEDURE getPhone
	@type VARCHAR (20) = 'em'
AS
BEGIN
	SELECT FirstName, LastName, PhoneNumber, Name FROM Person.Person
	INNER JOIN Person.PersonPhone on Person.Person.BusinessEntityID = Person.PersonPhone.BusinessEntityID
	INNER JOIN Person.PhoneNumberType on Person.PersonPhone.PhoneNumberTypeID = Person.PhoneNumberType.PhoneNumberTypeID
	WHERE PersonType = @type
END
GO