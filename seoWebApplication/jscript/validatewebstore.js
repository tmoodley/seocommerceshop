loadJavaScriptFile("/jscript/jquery.ui.core.min.js");
loadJavaScriptFile("/jscript/jquery.ui.widget.min.js");
loadJavaScriptFile("/jscript/jquery.ui.datepicker.min.js");
loadJavaScriptFile("/jscript/jquery.validate.min.js");
loadJavaScriptFile("/jscript/jquery.metadata.min.js");

function loadJavaScriptFile(jspath) {
    document.write('<script type="text/javascript" src="' + jspath + '"><\/script>');
}

function InitializeValidation() {
    var validator = $("#aspnetForm").bind("invalid-form.validate", function () { }).validate({
        errorElement: "em",
        errorPlacement: function (error, element) {
            error.appendTo(element.parent("td"));
        },
        success: function (label) {
            label.text("ok!").addClass("success");
        }
    });
}

function InitializeDatePicker(id) {
    $(id).datepicker({
        changeMonth: false,
        changeYear: false,
        showOn: "button",
        buttonImage: "/Images/Calendar.png",
        buttonImageOnly: true,
        onSelect: function (date) {
            this.focus()
        }
    });
}