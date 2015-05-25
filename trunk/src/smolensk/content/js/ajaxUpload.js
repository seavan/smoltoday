
jQuery.extend({


    createUploadIframe: function (id, uri) {
        //create frame
        var frameId = 'jUploadFrame' + id;
        var iframeHtml = '<iframe id="' + frameId + '" name="' + frameId + '" style="position:absolute; top:-9999px; left:-9999px"';
        if (window.ActiveXObject) {
            if (typeof uri == 'boolean') {
                iframeHtml += ' src="' + 'javascript:false' + '"';

            }
            else if (typeof uri == 'string') {
                iframeHtml += ' src="' + uri + '"';

            }
        }
        iframeHtml += ' />';
        jQuery(iframeHtml).appendTo(document.body);

        return jQuery('#' + frameId).get(0);
    },
    //createUploadForm: function (id, fileElementId, data) {
    createUploadForm: function (id, fileElementId, originalForm, data) {

        //create form	
        var formId = 'jUploadForm' + id;
        var fileId = 'jUploadFile' + id;
        var form = jQuery('<form  action="" method="POST" name="' + formId + '" id="' + formId + '" enctype="multipart/form-data"></form>');

        //fill from
        if (fileElementId && fileElementId.length > 0) {//Exist alone fileupload
            var oldElement = jQuery('#' + fileElementId);
            var newElement = jQuery(oldElement).clone();
            jQuery(oldElement).attr('id', fileId);
            jQuery(oldElement).before(newElement);
            jQuery(oldElement).appendTo(form);
        } else if (originalForm) { //Exist full form with elements
            //jQuery(form).html(jQuery(originalForm).html());
            jQuery.fillUploadForm(originalForm, form);
        } else if (data) {

            for (var i = 0; i < data.length; i++) {
                el = data[i];
                cln = document.createElement('input');

                var attrs = el.attributes;
                for (var i = 0; i < attrs.length; i++) {
                    cln.setAttribute(attrs[i].name, attrs[i].value);
                }
                try {
                    cln.value = el.value;
                } catch (e) {
                    //$(cln).attr('value', "");
                }


                cln.setAttribute('id', "inputFileClone_" + i);

                el.parentNode.replaceChild(cln, el);
                form[0].appendChild(el);
            }
        }

        //set attributes form
        jQuery(form).css('position', 'absolute');
        jQuery(form).css('top', '-1200px');
        jQuery(form).css('left', '-1200px');
        jQuery(form).appendTo('body');
        return form;
    },

    fillUploadForm: function (oldFrom, newForm) {

        var data = new Object();
        var $controls = oldFrom.find('input[type=text], input[type=password], input[type=hidden], input[type=checkbox], input[type=radio]:checked, textarea, select');
        for (i = 0; i < $controls.length; ++i) {
            var $i = $controls.eq(i);

            var name = $i.attr('name');

            if (name) {

                if (data[name] && data[name].length) {
                    continue;
                }

                var val = "";

                if ($i.find('option').length > 0) {
                    val = $i.find('option:selected').val();
                } else {
                    val = $i.val();
                }

                if ($i.attr('type') == 'checkbox') {
                    if ($i.attr('checked')) {
                        data[name] = 'True';
                    }
                    else {
                        data[name] = 'False';
                    }
                }
                else {
                    data[name] = val;
                }

            }
        }

        for (var i in data) {
            jQuery('<input type="hidden" name="' + i + '" value="' + data[i] + '" />').appendTo(newForm);
        }


        /*for file fileds*/
        var files = oldFrom.find('input[type=file]');

        for (var i = 0; i < files.length; i++) {

            el = files.eq(i)[0];
            cln = document.createElement('input');

            var attrs = el.attributes;
            for (var i = 0; i < attrs.length; i++) {
                cln.setAttribute(attrs[i].name, attrs[i].value);
            }
            try {
                cln.value = el.value;
            } catch (e) {
                //$(cln).attr('value', "");
            }


            cln.setAttribute('id', "inputFileClone_" + i);

            el.parentNode.replaceChild(cln, el);
            newForm[0].appendChild(el);
        }

    },

    ajaxUpload: function (s) {
        // TODO introduce global settings, allowing the client to modify them for all requests, not only timeout		
        s = jQuery.extend({}, jQuery.ajaxSettings, s);
        var id = new Date().getTime()
        //var form = jQuery.createUploadForm(id, s.fileElementId, (typeof (s.data) == 'undefined' ? false : s.data));
        var form = jQuery.createUploadForm(id, (typeof (s.fileElementId) == 'undefined' ? false : s.fileElementId), (typeof (s.form) == 'undefined' ? false : s.form), (typeof (s.data) == 'undefined' ? false : s.data));

        var io = jQuery.createUploadIframe(id, s.secureuri);
        var frameId = 'jUploadFrame' + id;
        var formId = 'jUploadForm' + id;
        // Watch for a new set of requests
        if (s.global && !jQuery.active++) {
            jQuery.event.trigger("ajaxStart");
        }
        var requestDone = false;
        // Create the request object
        var xml = {}
        if (s.global)
            jQuery.event.trigger("ajaxSend", [xml, s]);
        // Wait for a response to come back
        var uploadCallback = function (isTimeout) {

            var io = document.getElementById(frameId);
            window.setTimeout(function () {
                if (!xml) return;
                try {
                    if (io.contentWindow) {
                        xml.responseText = io.contentWindow.document.body ? io.contentWindow.document.body.innerHTML : null;
                        xml.responseXML = io.contentWindow.document.XMLDocument ? io.contentWindow.document.XMLDocument : io.contentWindow.document;

                    } else if (io.contentDocument) {
                        xml.responseText = io.contentDocument.document.body ? io.contentDocument.document.body.innerHTML : null;
                        xml.responseXML = io.contentDocument.document.XMLDocument ? io.contentDocument.document.XMLDocument : io.contentDocument.document;
                    }
                } catch (e) {
                    jQuery.handleError(s, xml, null, e);
                }
                if (xml || isTimeout == "timeout") {
                    requestDone = true;
                    var status;
                    try {
                        status = isTimeout != "timeout" ? "success" : "error";
                        // Make sure that the request was successful or notmodified
                        if (status != "error") {
                            // process the data (runs the xml through httpData regardless of callback)
                            var data = jQuery.uploadHttpData(xml, (typeof (s.dataType) == 'undefined' ? "html" : s.dataType));
                            // If a local callback was specified, fire it and pass it the data
                            if (s.success)
                                s.success(data, status);

                            // Fire the global callback
                            if (s.global)
                                jQuery.event.trigger("ajaxSuccess", [xml, s]);
                        } else
                            jQuery.handleError(s, xml, status);
                    } catch (e) {
                        status = "error";
                        jQuery.handleError(s, xml, status, e);
                    }

                    // The request was completed
                    if (s.global)
                        jQuery.event.trigger("ajaxComplete", [xml, s]);

                    // Handle the global AJAX counter
                    if (s.global && ! --jQuery.active)
                        jQuery.event.trigger("ajaxStop");

                    // Process result
                    if (s.complete)
                        s.complete(xml, status);

                    jQuery(io).unbind()

                    setTimeout(function () {
                        try {
                            jQuery(io).remove();
                            jQuery(form).remove();

                        } catch (e) {
                            jQuery.handleError(s, xml, null, e);
                        }

                    }, 100)

                    xml = null

                }
            }, 1000);
        }
        // Timeout checker
        if (s.timeout > 0) {
            setTimeout(function () {
                // Check to see if the request is still happening
                if (!requestDone) uploadCallback("timeout");
            }, s.timeout);
        }
        try {

            var form = jQuery('#' + formId);
            jQuery(form).attr('action', s.url);
            jQuery(form).attr('method', 'POST');
            jQuery(form).attr('target', frameId);
            if (form.encoding) {
                jQuery(form).attr('encoding', 'multipart/form-data');
            }
            else {
                jQuery(form).attr('enctype', 'multipart/form-data');
            }
            jQuery(form).submit();

        } catch (e) {
            jQuery.handleError(s, xml, null, e);
        }

        jQuery('#' + frameId).eq(0).load(uploadCallback);
        return { abort: function () { } };

    },

    uploadHttpData: function (r, type) {
        var data = !type;
        data = type == "xml" || data ? r.responseXML : r.responseText;
        // If the type is "script", eval it in global context
        if (type == "script")
            jQuery.globalEval(data);
        // Get the JavaScript object, if JSON is used.
        if (type == "json")
            eval("data = " + data);
        //        // evaluate scripts within html
        //        if (type == "html")
        //            jQuery("<div>").html(data).evalScripts();
        if (data.length <= 0)
        { jQuery("<div>").html(data).evalScripts(); }
        return data;
    }
})

