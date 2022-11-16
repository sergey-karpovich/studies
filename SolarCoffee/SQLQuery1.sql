USE [SolarCoffee]
GO

Insert into [dbo].[Products] (    
    CreatedOn  ,UpdatedOn,Name,Description,Price,
    IsTaxable , IsArchived  
)
values 
(GETDATE(), GETDATE(), '10 LB Dark Roast','10 LB bag of dark roast coffee beans',100, 0,0),
(GETDATE(), GETDATE(), '30 LB Dark Roast', '10 LB bag of dark roast coffee beans',100, 0,0),
(GETDATE(), GETDATE(), '50 LB Dark Roast' ,'10 LB bag of dark roast coffee beans',100, 0,0),
(GETDATE(), GETDATE(), '10 LB Light Roas' ,'10 LB bag of dark roast coffee beans',100,0,0),
(GETDATE(), GETDATE(), '30 LB Light Roas' ,'30 LB bag of dark roast coffee beans',100,0,0),
(GETDATE(), GETDATE(), '50 LB Light Roas' ,'50 LB bag of dark roast coffee beans',100,0,0)



