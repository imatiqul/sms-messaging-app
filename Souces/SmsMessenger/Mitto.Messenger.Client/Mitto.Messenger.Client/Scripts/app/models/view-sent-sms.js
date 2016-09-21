// models
var viewSMSViewModel = kendo.observable({

  init: function () {
    console.log("view init");

    $("#view-sms-from-date").kendoDateTimePicker({
      format: "yyyy-MM-dd hh:mm:ss"
    });
    $("#view-sms-to-date").kendoDateTimePicker({
      format: "yyyy-MM-dd hh:mm:ss"
    });
  },

  show: function () {
    console.log("view show");
  },

  viewSentSmsClick: function () {
    alert("viewSentSms clicked");
  },

  clearClick: function (e) {
    alert("clear clicked");
  }
});
