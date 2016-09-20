$(document).ready(function () {
  var countryDataSource = new kendo.data.DataSource({
    transport: {
      read: {
        url: getCountriesUrl,
        dataType: "jsonp"
      }
    }
  });

  $("#countries-grid").kendoGrid({
    columns: [
        { field: "mcc" },
        { field: "cc" },
        { field: "name" },
        { field: "pricePerSMS" }
    ],
    dataSource: countryDataSource
  });

});

