// models
var reportViewModel = kendo.observable({

  init: function () {
    console.log("view init");

    $("#report-from-date").kendoDatePicker({
      format: "yyyy-MM-dd",
    });
    $("#report-to-date").kendoDatePicker({
      format: "yyyy-MM-dd"
    });

    $("#mcc-list").kendoListView({
      dataSource: countryDataSource,
      template: kendo.template($("#lst-country-template").html()),
      selectable: "multiple"
    });

  },

  show: function () {
    console.log("view show");
  },

  generateReportClick: function () {
    alert("generateReport clicked");
  },

  clearClick: function (e) {
    alert("clear clicked");
  }
});