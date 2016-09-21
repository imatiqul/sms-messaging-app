// models
var sendSMSViewModel = kendo.observable({

  init: function () {
    console.log("view init");

    $("#ddl-sender-country").kendoDropDownList({
      dataTextField: "name",
      dataValueField: "mcc",
      template: kendo.template($("#ddl-country-template").html()),
      dataSource: countryDataSource,
      noDataTemplate: 'No Country Found!',
      change: function (e) {
      }
    });

    $("#ddl-receiver-country").kendoDropDownList({
      dataTextField: "name",
      dataValueField: "mcc",
      template: kendo.template($("#ddl-country-template").html()),
      dataSource: countryDataSource,
      noDataTemplate: 'No Country Found!',
      change: function (e) {
      }
    });

    $("#sms-text").kendoEditor({
      tools: [
      ]
    });

  },

  show: function () {
    console.log("view show");
  },

  sendSmsClick: function (e) {
    alert("sendSmsClick clicked");
    goToViewSentSms(e);
  },
  cancelClick: function (e) {
    alert("cancel clicked");
    goToViewSentSms(e);
  },

  clearClick: function (e) {
    alert("clear clicked");
  },

  goToViewSentSms: function (e) {
    router.navigate("/view-sms");
    e.preventDefault();
  }
});
