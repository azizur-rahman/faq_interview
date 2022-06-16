/**
Makes the textbox to accept only numeric input
*/

(function ($) {
    $.fn.numeric = function (options) {

        var defaults = {
            digitsOnly: false,
            allowDot: true,
            allowDash: true,
            allowPlus: true,
            allowSpace: true
        };

        var settings = $.extend({}, defaults, options);

        /**
        Checks whether the key is only numeric.
        */
        var isValid = function (key) {
            var validChars = '0123456789';

            if (!settings.digitsOnly) {
                if (settings.allowDot) {
                    validChars += '.';
                }
                if (settings.allowDash) {
                    validChars += '-';
                }
                if (settings.allowPlus) {
                    validChars += '+';
                }
                if (settings.allowSpace) {
                    validChars += ' ';
                }
            }

            var validChar = validChars.indexOf(key) != -1;
            return validChar;
        };

        /**
        Fires the key down event to prevent the control and alt keys
        */
        var keydown = function(evt) {
            if (evt.ctrlKey || evt.altKey) {
                evt.preventDefault();
            }
        };

        /**
        Fires the key press of the text box   
        */
        var keypress = function(evt) {
            var scanCode;
            //scanCode = evt.which;
            if (evt.charCode) { //For ff
                scanCode = evt.charCode;
            } else { //For ie
                scanCode = evt.keyCode;
            }

            if (scanCode && scanCode >= 0x20 /* space */) {
                var c = String.fromCharCode(scanCode);
                if (!isValid(c)) {
                    evt.preventDefault();
                }
            }
        };

        /**
        Fires the lost focus event of the textbox   
        */
        var onchange = function() {
            var result = [];
            var enteredText = $(this).val();
            for (var i = 0; i < enteredText.length; i++) {
                var ch = enteredText.substring(i, i + 1);
                if (isValid(ch)) {
                    result.push(ch);
                }
            }
            var resultString = result.join('');
            if (enteredText != resultString) {
                $(this).val(resultString);
            }

        };

        //var _filterInterval = 250;
        //var _intervalID = null;

        //var _intervalHandler = null;

        /**
        Dispose of the textbox to unbind the events.
        */
        this.dispose = function() {
            $(this).off('change', onchange);
            $(this).off('keypress', keypress);
            $(this).off('keydown', keydown);
            //window.clearInterval(_intervalHandler);
        };

        $(this).on('change', onchange);
        $(this).on('keypress', keypress);
        $(this).on('keydown', keydown);
        //_intervalHandler = createDelegate(this, onchange);
        //_intervalID = window.setInterval(_intervalHandler, _filterInterval);
    };
})(jQuery);