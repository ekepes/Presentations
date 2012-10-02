namespace MicroORMs.Web.Models
{
    public class EmbeddedSql
    {
        public const string OldSkoolQueryText = "SELECT "
                                                + "  Person.StateProvince.StateProvinceCode, "
                                                + "	YEAR(Sales.SalesOrderHeader.ShipDate) AS SalesYear, "
                                                + "	MONTH(Sales.SalesOrderHeader.ShipDate) AS SalesMonth, "
                                                + "	SUM(Sales.SalesOrderDetail.LineTotal) AS MonthlySales "
                                                + "FROM "
                                                + "	Sales.SalesOrderDetail "
                                                +
                                                "	INNER JOIN Sales.SalesOrderHeader ON Sales.SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID "
                                                +
                                                "	INNER JOIN Person.Address ON Sales.SalesOrderHeader.ShipToAddressID = Person.Address.AddressID "
                                                +
                                                "	INNER JOIN Person.StateProvince ON Person.Address.StateProvinceID = Person.StateProvince.StateProvinceID "
                                                + "WHERE "
                                                + "	 Person.StateProvince.CountryRegionCode = 'US' "
                                                + "GROUP BY "
                                                + "	Person.StateProvince.StateProvinceCode, "
                                                + "	YEAR(Sales.SalesOrderHeader.ShipDate), "
                                                + "	MONTH(Sales.SalesOrderHeader.ShipDate) "
                                                + "ORDER BY "
                                                + "	Person.StateProvince.StateProvinceCode, "
                                                + "	YEAR(Sales.SalesOrderHeader.ShipDate), "
                                                + "	MONTH(Sales.SalesOrderHeader.ShipDate)";

        public const string PetaPocoQueryText = "SELECT "
                                                + "  Person.StateProvince.StateProvinceCode AS StateCode, "
                                                + "	YEAR(Sales.SalesOrderHeader.ShipDate) AS SalesYear, "
                                                + "	MONTH(Sales.SalesOrderHeader.ShipDate) AS SalesMonth, "
                                                + "	SUM(Sales.SalesOrderDetail.LineTotal) AS MonthlySales "
                                                + "FROM "
                                                + "	Sales.SalesOrderDetail "
                                                +
                                                "	INNER JOIN Sales.SalesOrderHeader ON Sales.SalesOrderDetail.SalesOrderID = Sales.SalesOrderHeader.SalesOrderID "
                                                +
                                                "	INNER JOIN Person.Address ON Sales.SalesOrderHeader.ShipToAddressID = Person.Address.AddressID "
                                                +
                                                "	INNER JOIN Person.StateProvince ON Person.Address.StateProvinceID = Person.StateProvince.StateProvinceID "
                                                + "WHERE "
                                                + "	 Person.StateProvince.CountryRegionCode = 'US' "
                                                + "GROUP BY "
                                                + "	Person.StateProvince.StateProvinceCode, "
                                                + "	YEAR(Sales.SalesOrderHeader.ShipDate), "
                                                + "	MONTH(Sales.SalesOrderHeader.ShipDate) "
                                                + "ORDER BY "
                                                + "	Person.StateProvince.StateProvinceCode, "
                                                + "	YEAR(Sales.SalesOrderHeader.ShipDate), "
                                                + "	MONTH(Sales.SalesOrderHeader.ShipDate)";
    }
}