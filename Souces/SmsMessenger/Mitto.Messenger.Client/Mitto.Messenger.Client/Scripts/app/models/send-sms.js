// models
var sendSMSViewModel = kendo.observable({
  sms: {
    message: "",
    country: null,
    senderMobile: "",
    receiverMobile: ""
  },

  dataSource: new kendo.data.DataSource({
    transport: {
      create: {
        url: sendSmsApiUrl,
        error: function (xhr, error) {
          console.debug(xhr); console.debug(error);
          alert('error');
        },
        dataType: "json" // "jsonp" is required for cross-domain requests; use "json" for same-domain requests        

      },
      parameterMap: function (data, type) {
        if (type == "create") {
          var paramData = data;
          return $.param(paramData);
        }
      },
      requestEnd: function (e) {
        //check the "response" argument to skip the local operations
        if (e.type === "create" && e.response) {
          if (e.response.hasOwnProperty('status')) {

          }

        }
      }
    },
    batch: false,
    schema: {
      model: {
        from: "",
        to: "",
        text: ""
      }
    }
  }),

  validator: $('#send-sms-form').kendoValidator().data('kendoValidator'),

  init: function () {
    $("#ddl-country").kendoDropDownList({
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

  },

  validate: function () {
    var messageSummary = $("#message-summary");
    var html = "";

    if (this.validator.validate() === false) {
      var errors = this.validator.errors();
      for (var index = 0; index < errors.length; index++) {
        html += "<li>" + errors[index] + "</li>";
      }
      messageSummary.empty().append($(html));
      return false;
    }
    return true;
  },

  sendSmsClick: function (e) {
    //if (!this.validate()) {
    //  return -1;
    //}

    var _sms = this.get("sms");
    var sender = _sms.country.cc + _sms.country.mcc + _sms.senderMobile;
    var receiver = _sms.country.cc + _sms.country.mcc + _sms.receiverMobile;

    var smsRequest = {
      from: sender,
      to: receiver,
      text: _sms.message
    };

    this.dataSource.add(smsRequest);
    this.dataSource.sync();
    this.dataSource.remove(this.dataSource.at(0));
    this.clearClick(e);
    this.goNext(e);
  },
  cancelClick: function (e) {
    this.clearClick(e);
    this.goNext(e);
  },

  clearClick: function (e) {
    this.set("sms", {
      message: "",
      country: null,
      senderMobile: "",
      receiverMobile: ""
    })
  },

  goNext: function (e) {
    router.navigate("/view-sms");
    e.preventDefault();
  }
});
