// models
var sendSMSViewModel = kendo.observable({

  sms: {
    message: "",
    senderCountry: null,
    senderMobile: "",
    receiverCountry: null,
    receiverMobile: ""
  },

  init: function () {

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
    var _sms = this.get("sms");
    var sender = '+' + _sms.senderCountry.cc + _sms.senderCountry.mcc + _sms.senderMobile;
    var receiver = '+' + _sms.receiverCountry.cc + _sms.receiverCountry.mcc + _sms.receiverMobile;

    var smsRequest = [
      from = sender,
      to = receiver,
      text = _sms.message
    ];

    $.ajax({
      type: "GET",
      url: sendSmsApiUrl + '?from='+encodeURIComponent(sender)+'&to='+encodeURIComponent(receiver)+'&text='+encodeURIComponent(text),
      dataType: "json",
      contentType: 'application/json; charset=utf-8',
      error: function (xhr) {
        alert('Error: ' + xhr.statusText);
      },
      success: function (result) {
        console.log(result);
      },
      async: true,
      processData: false
    });


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
