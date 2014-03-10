
/*
By Samuel Bamgboye v1.0.15 | 2013
*/

;var $viewbinder$fd = function($) {
    //===========================================================================
    //api
    //===========================================================================
    var pageviewAttr = "data-viewbind-pageview";
    var bootstrap = "data-viewbind-init";
    var modelAttr = "data-viewbind-model";
    var notifycastAttr = "data-viewbind-notify";
    var broadcastAttr = "data-viewbind-cast";
    var eventAttr = "data-viewbind-event";
    var callBackAttr = "data-viewbind-call";
    var refAtLocator = "data-viewbind-view";
    var refviewarea = "data-viewbind-viewarea";
    var refviewdelay = "data-viewbind-viewdelay";
    //===========================================================================

    var actionAttr = "data-viewbind-action";
    var effectsOnLoad = "data-viewbind-effect";
    var refExLocator = refAtLocator + "-x";
    var refErrLocator = refAtLocator + "-error";
    var igniter = "viewbind";

    var selector = "." + igniter;

    var rootUrl = "";
    var notification = {
        subscribers:[],
        subscribe: function (f) {
            if (f) {
                if (typeof f === "function") {
                    this.subscribers.push(f);
                }
            } 
        },
        error: function (obj) {
            this.notifySubscribers(obj || {}, 1);
            console && console.error(obj);
        },
        warn: function (obj) {
            this.notifySubscribers(obj || {}, 2);
            console && console.warn(obj);
        },
        notifySubscribers: function (obj, type) {
            (function(that) {
                setTimeout(function () {
                    type = type || 1;
                    var length = that.subscribers.length;
                    for (var i = 0; i < length; i++) {
                        try {
                            that.subscribers[i](obj, type);
                        } catch (exc) {
                            console && console.error("Subscriber Notification Malfunction")
                        }

                    }
                },0);
            })(this);
        }
    };


    var identityGenerator = function() {
        identityGenerator.id = identityGenerator.id ? (identityGenerator.id + 1) : 1;
        return identityGenerator.id;
    };
    var delayViewTrigger = function(view) {
        if (view) {

            $("[" + refAtLocator + "='" + view + "']").removeAttr(refviewdelay);
        
        }
    };

    var unloadView = function(view) {
        if (view) {
            $("[" + refAtLocator + "='" + view + "']").empty();
     
        }
    };

    var reloadView = function(view) {
        if (view) {

            if (view.split('=')[1]) {
                if ($("[" + refAtLocator + "='" + view + "']").size()) {
                    var eleObj1 = $("[" + refAtLocator + "='" + view + "']");
                    eleObj1.removeAttr(refviewdelay).removeAttr(refExLocator).empty();
                } else {
                    $('body').append('<div style="display:none" class="viewbind"  data-viewbind-view="' + view + '"></div>');
                }

            } else {
                var eleObj = $("[" + refAtLocator + "='" + view + "']");

                eleObj.removeAttr(refviewdelay);
                eleObj.removeAttr(refExLocator);
                eleObj.html("");
            }

            $viewbinderViewLoader("[" + refAtLocator + "='" + view + "']");
        }
    };
    var viewControl = {
        load: reloadView,// delayViewTrigger,
        unload: unloadView,
        reload: reloadView
    };

    var inPageViewGet = function(src, onViewRetrieved) {
        var inpage = $("script[type='text/plain'][" + pageviewAttr + "='" + src + "']");
        var size = inpage.size();
        var html = size && inpage.html();
        size && onViewRetrieved && onViewRetrieved(html);
        return size;
    };

    var loadViewWithEffect = function(destinationRef, rootUrl, viewUrl, callback, effect, isViewArea) {
        if (isViewArea) {
            (typeof callback === "function" && callback("", "", ""));
            return;
        }

        if (destinationRef && viewUrl) {
            rootUrl = rootUrl || "";
            var oldContext = destinationRef;


            var viewParts = viewUrl.split("=");

            var destination = viewParts[0];
            var source = viewParts[1];
            var inPageSource = "";
            var accessDestination = destination;
            if (!source) {
                inPageSource = destination;
                accessDestination = destinationRef;
                source = rootUrl + destination;

            } else {
                inPageSource = source;
                source = rootUrl + source;

                accessDestination = "[" + refAtLocator + "='" + destination + "']";

            }


            var dest = $(accessDestination);
            effect && dest.css("display", "none");

            var onViewRetrieved = function(data) {
                dest.html(data);
                dest.attr("processed","gas")


                effect ? dest[effect]("fast", function() { typeof callback === "function" && callback(data, "", ""); }) :
                    (typeof callback === "function" && callback(data, "", ""));

            };


            if (dest.size()) {
                inPageViewGet(inPageSource, onViewRetrieved) || $.get(source, onViewRetrieved, "html");
            } else {
                notification.error("destination view area cannot be found as specified at :");
                notification.error(oldContext);
                (typeof callback === "function" && callback({}, "", ""));
            }


        }

    };

    var bCastObject = {
        
    };

    var viewLinking = [];
    var methodArgExtrator = function(modelRef, context) {
        var MetArg = {};

        if (modelRef) {
            var parts = modelRef.split("=");
            if (parts[0] === "target") {
                if (parts[1]) {
                    MetArg = parts[3] ? $(parts[1])[parts[2]](parts[3]) : $(parts[1])[parts[2]]();
                } else {
                    notification.error("target not well specified for :");
                    notification.error(context);
                }

            } else {
                MetArg = parts[1] ? $(context)[parts[0]](parts[1]) : $(context)[parts[0]]();
            }

        }
        return MetArg;
    };
    var getFunctionFromString = function(string) {
        var scope = window;
        var scopeSplit = string.split('.');

        var length1 = scopeSplit.length - 1;
        for (i = 0; i < length1; i++) {
            scope = scope[scopeSplit[i]];

            if (scope == undefined) return;
        }


        return {
            method: scope[scopeSplit[scopeSplit.length - 1]],
            context: scope,
        };
    };
    var eventSetup = function(_setting, element, modelRef) {
        if (_setting) {
            var allSettings = _setting.split(",");
            var allSettingsLength = allSettings.length;
            for (var i = 0; i < allSettingsLength; i++) {
                var setting = allSettings[i];
                if (setting) {
                    var arr = setting.split("=");
                    if (arr.length === 2) {
                        var ev = arr[0];
                        var fun = arr[1];
                        var fn = getFunctionFromString(fun).method;

                        typeof fn === "function" && element && ev && $(element).off(ev).on(ev, function(e) {
                            var MetArg = methodArgExtrator(modelRef, this);


                            fn.apply(this, [e, viewControl, MetArg]);
                        });


                    }
                }
            }


        }
    };

    var actionSetup = function(setting, element, isMethodbroadcast, bCastArg, modelRef) {


    };
    var executeActionByString = function(action) {
        var actParts = action.split("(");
        var method = actParts[0];
        var arg = actParts[1].split(")")[0];

        if (arg && (typeof viewControl[method] === "function")) {
            return function() {
                viewControl[method](arg);

            };
        } else {
            notification.error("methos supplied is invalid:");
            notification.error(action);
            return function() {
            };
        }

    };
    var broadcastSetup = function(_setting, element, isMethodbroadcast, bCastArg, modelRef) {
        if (_setting) {
            var allSettings = _setting.split(",");
            var allSettingsLength = allSettings.length;
            for (var i = 0; i < allSettingsLength; i++) {
                var setting = allSettings[i];

                var bcastAction = false;
                var actionSetting = "";
                if (setting) {

                    var arr1 = setting.split(":");
                    if (arr1.length === 2) {
                        var bSettings = arr1[0];
                        actionSetting = arr1[1];
                        bcastAction = actionSetting && executeActionByString(actionSetting);
                        setting = bSettings;


                    }
                }
                if (setting) {

                    var arr = setting.split("=");
                    if ((arr.length === 2) || bcastAction) {
                        var ev = arr[0];
                        var fun = arr[1] || "i299792458";


                        bCastObject[fun] = bCastObject[fun] || [];

                        if (isMethodbroadcast) {
                            var bcasts = bCastObject[fun];
                            var bcastsLength = bcasts.length;
                            if (bcastsLength === 0) {
                                notification.warn("No Listeners registered to receive this notification : " + fun);
                            }

                            for (var ii = 0; ii < bcastsLength; ii++) {
                                var callingContext =( typeof element !== "string")?element : this;
                                typeof bcasts[ii] === "function" && bcasts[ii].apply(callingContext, [{}, viewControl, bCastArg]);
                            }

                        } else {

                            element && ev && $(element).off(ev).on(ev, function(e) {
                                var bcasts = bCastObject[fun];
                                var MetArg = methodArgExtrator(modelRef, this);
                                var bcastsLength = bcasts.length;
                                bcastAction && bcastAction();
                                
                                if (bcastsLength === 0) {
                                    notification.warn("No Listeners registered to receive this notification : " + fun);
                                }

                                for (var ij = 0; ij < bcastsLength; ij++) {

                                    (function(that, bcasts, viewControl, MetArg, e) {
                                       // setTimeout(function() {
                                            bcasts.apply(that, [e, viewControl, MetArg]);

                                        //}, 0);
                                    })(this, bcasts[ij], viewControl, MetArg, e);

                                }

                            });
                        }


                    }
                }
            }
           
        }

    };

    var stringMethodCall = function(_method, context, modelRef) {
        if (_method) {
            var allSettings = _method.split(",");
            var allSettingsLength = allSettings.length;
            for (var i = 0; i < allSettingsLength; i++) {
                var method = allSettings[i];
                if (method) {
                    try {
                        var fn = getFunctionFromString(method);
                        context = fn ? (fn.context || context) : context;

                        var MetArg = methodArgExtrator(modelRef, this);

                        fn && typeof fn.method === "function" && fn.method.apply(context, [{}, viewControl, MetArg]);

                    } catch(execp) {
                        notification.error("could not invoke method " + method + " found in " + _method);
                        execp.message && notification.error(execp.message);
                        notification.error(execp);
                    }
                }
            }
        }


    };
    var broadcastMehtod = function(bCastName, bCastObject, sender) {

        var bCastNameParts = bCastName.split(',');
        var length = bCastNameParts.length;
        var argBuild = "";
        for (var i = 0; i < length; i++) {
            argBuild = "cast=" + bCastNameParts[i];
        }

        bCastName && broadcastSetup(argBuild, sender || {}, true, bCastObject || "");
    };
    var notifyMethodCall = function(broadCastEvent, context, modelRef) {
        var MetArg = methodArgExtrator(modelRef, context);
        broadCastEvent && broadcastMehtod(broadCastEvent, MetArg || "", context);
    };
    typeof  viewbinder!=='undefined' ?notification.error("multiple versions of view binder on page"):
    window.viewbinder = {
        init: function(settings) {
            if (settings) {
                rootUrl = settings.rootUrl || rootUrl;
            }
            $(function() {


                window.$viewbinderViewLoader = function(ref) {
                    $(ref).each(function() {
                        if ($(this).is("[" + refviewdelay + "]") || $(this).attr(refExLocator)) {

                        } else {
                            try {


                                var url = $(this).attr(refAtLocator);
                                var effectToLoadWith = $(this).attr(effectsOnLoad);

                                var isViewArea = $(this).is("[" + refviewarea + "]");

                                if (isViewArea) {
                                    $(this).removeAttr(refviewarea);
                                }

                                var context = this;
                             
                                var loadEventHandler = function (response, status, xhr) {
                                    
                                  

                                    var callback2 = $(context).attr(callBackAttr);
                                    if (status == "error") {
                                        notification.error("failure loading view - " + url + ":");
                                        notification.error(response);
                                        notification.error(xhr);
                                        $(this).attr(refErrLocator, true);
                                    }


                                    (function (context) {

                                        setTimeout(function () {

                                            var url = $(context).attr(refAtLocator);
                                            var notifySet = $(context).attr(notifycastAttr);
                                            var callback = $(context).attr(callBackAttr);
                                            var eventSet = $(context).attr(eventAttr);
                                            var bCastSet = $(context).attr(broadcastAttr);
                                            var modelRef = $(context).attr(modelAttr);
                                            var actionSet = $(context).attr(actionAttr);
                                            callback && stringMethodCall(callback, context, modelRef);
                                            eventSet && eventSetup(eventSet, context, modelRef);
                                            bCastSet && broadcastSetup(bCastSet, context, false, false, modelRef);
                                            notifySet && notifyMethodCall(notifySet, context, modelRef);
                                            actionSet && actionSetup(bCastSet, context, false, false, modelRef);

                                            var subViews = $(context).find(selector);
                                   
                                        $viewbinderViewLoader(subViews);
                                    
                                        }, 50);
                                    })(context);


                                };

                         
                                if (url) {
                                    loadViewWithEffect(this, rootUrl, url, loadEventHandler, effectToLoadWith || "", isViewArea);
                                } else {
                                    loadEventHandler("","","");
                                }
                                $(this).attr(refExLocator, true);

                            } catch(exc) {
                                notification.error("failure loading view - " + url + ":");
                                notification.error(exc);
                                $(this).attr(refErrLocator, true);
                            }
                        }

                    });
                };

                $viewbinderViewLoader(selector);
            });
        },
        on: function(bCastName, f) {
            if (typeof f === "function" && bCastName) {

                bCastObject[bCastName] = bCastObject[bCastName] || [];
                bCastObject[bCastName].push(f);

            } else {
                notification.error("Problem Registering Listener for:");
                notification.error(bCastName);
                notification.error("with method:");
                notification.error(f);
            }
        },
        notify: broadcastMehtod,
        view: viewControl,
        mappings: function() {

            return {
                broadcast: bCastObject,
                views: viewLinking
            };
        },
        notification: notification
    };


    $(function() {
        var script = $("script[" + bootstrap + "]");
        if (script.size()) {
            var initObject = {};
            var initVal = script.attr(bootstrap);
            if (initVal) {
                var param = initVal.split(",");
                var length = param.length;
                for (var i = 0; i < length; i++) {
                    var parts = param[i].split("rootUrl:");

                    initObject.rootUrl = parts[1];

                }

            }
            viewbinder.init(initObject);


        }
    });
    return viewbinder;
};
typeof define === "function" ? define(["jquery"], $viewbinder$fd) : (function ($) { $ ? $viewbinder$fd(jQuery) : notification.error("Jquery is not defined"); })(jQuery);
