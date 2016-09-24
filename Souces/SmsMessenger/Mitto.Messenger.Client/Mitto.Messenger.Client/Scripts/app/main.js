$(document).ready(function () {
  // views, layouts
  var layout = new kendo.Layout("<div id='content'></div>");

  var sendSMS = new kendo.View("send-sms-template", { model: sendSMSViewModel, init: sendSMSViewModel.init.bind(sendSMSViewModel), show: sendSMSViewModel.show.bind(sendSMSViewModel) });
  var viewSMS = new kendo.View("view-sms-template", { model: viewSMSViewModel, init: viewSMSViewModel.init.bind(viewSMSViewModel), show: viewSMSViewModel.show.bind(viewSMSViewModel) });
  var report = new kendo.View("report-template", { model: reportViewModel, init: reportViewModel.init.bind(reportViewModel), show: reportViewModel.show.bind(reportViewModel) });

  // routing
  
  router.bind("init", function () {
    layout.render($("#messanger-app"));
  });

  router.route("/send-sms", function () {
    layout.showIn("#content", sendSMS);
  });

  router.route("/view-sms", function () {
    layout.showIn("#content", viewSMS);
  });

  router.route("/report", function () {
    layout.showIn("#content", report);
  });

  $(function () {
    router.start();
    router.navigate("/send-sms");
  });
});

