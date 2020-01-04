
(function($) {
    'use strict';

    /*\
     *
     * Others
     *
    \*/
    try {
        if($('.parallax100').length > 0) {
            $('.parallax100').parallax100();
        }

        if($('.js-tilt').length > 0) {
            $('.js-tilt').tilt();
        }

        // Full height with header
        $(window).on('load resize', function() {
            if(!$('.hun-header').hasClass('style-overlay')) {
                var heightHeader = $('.hun-header').outerHeight();
                var heightWindow = $(window).outerHeight();

                $('.full-height-with-header').css('min-height', heightWindow - heightHeader + 'px');
            }
        });

    } catch(er) {console.log(er);}

    /*\
     *
     * slideSlick
     *
    \*/
    try {
        $('.js-call-slick').each(function(){
            var $wrapperSlick = $(this);
            var $slideSlick = $(this).find('.slide-slick');
            var $itemSlick = $slideSlick.find('.item-slick');

            var dataCustomDots = $wrapperSlick.data('custom-dots');
            var dataHeightArrows = $wrapperSlick.data('height-arrows');
            var dataAnimate = $wrapperSlick.data('animate');

            if(dataAnimate === true) {
                var $layerSlick = $slideSlick.find('[data-appear]');
                var actionSlick = [];

                $layerSlick.addClass('animated').css('visibility', 'hidden');
            }  

            /*---------------------------------------------*/
            $slideSlick.on('init', function(event, slick){
                if(dataAnimate === true) {
                    showLayer(0);
                }
            });

            $slideSlick.slick({
                appendArrows: $wrapperSlick.find('.arrows-slick'),
                prevArrow: $wrapperSlick.find('.prev-slick'),
                nextArrow: $wrapperSlick.find('.next-slick'),
                appendDots: $wrapperSlick.find('.dots-slick'),

                customPaging: function(slick, index) {
                    var innerDot = $(slick.$slides[index]).data('inner-dot');

                    if(dataCustomDots === true) return innerDot;

                    return '<span class="inner-dot"></span>';
                }
            });

            $slideSlick.on('setPosition', function(event, slick){
                // Equal height
                if($wrapperSlick.data('equal-height') === true) {
                    var maxHeight = 0;
                    var $items = $(this).find('.item-slick');

                    $items.each(function(){
                        if($(this).outerHeight() > maxHeight) {
                            maxHeight = $(this).outerHeight();
                        }
                    })

                    $items.css('min-height', maxHeight);
                }

                // Middle Arrow
                if(dataHeightArrows != null) {
                    var $wrapperArrows = $wrapperSlick.find('.arrows-slick');
                    var heightWA = $wrapperSlick.find(dataHeightArrows).outerHeight();
                    
                    $wrapperArrows.css('height', heightWA + 'px');
                }

                // Disable centerMode
                if (slick.slideCount <= slick.options.slidesToShow) {
                    $slideSlick.slick('slickSetOption', 'centerMode', false);
                    $slideSlick.find('.item-slick').removeClass('slick-center');
                }
            });

            $slideSlick.on('afterChange', function(event, slick, currentSlide){ 
                if(dataAnimate === true) {
                    showLayer(currentSlide);
                }
            });

            /*---------------------------------------------*/
            function showLayer(currentSlide) {
                var $layerCurrentItem = $($itemSlick[currentSlide]).find('[data-appear]');

                for(var i=0; i<actionSlick.length; i++) {
                    clearTimeout(actionSlick[i]);
                }

                $layerSlick.each(function(){
                    $(this).removeClass($(this).data('appear')).css('visibility', 'hidden');
                })
                    

                for(var i=0; i<$layerCurrentItem.length; i++) {
                    actionSlick[i] = setTimeout(function(index) {
                        $($layerCurrentItem[index]).addClass($($layerCurrentItem[index]).data('appear')).css('visibility', 'visible');
                    },$($layerCurrentItem[i]).data('delay'),i); 
                }
            };
        });
    } catch(er) {console.log(er);}

    /*\
     *
     * magnificPopup
     *
    \*/
    try {
        $('.js-call-magnificpopup').each(function() {
            var $thisObj = $(this);
            var data =      [
                                'gallery',
                                'verticalfit',
                                'focus',
                                'popupinside',
                                'fixedpos'
                            ]

            var option =    {
                                gallery: false,
                                verticalfit: true,
                                focus: '',
                                popupinside: false,
                                fixedpos: true
                            }

            // Get data
            for(var i=0; i<data.length; i++) {
                var value = $thisObj.data(data[i]); 

                if (value != null) {
                    option[data[i]] = value;
                }
            }

            var prepend = $(document.body);
            if(option.popupinside === true) { console.log(222);
                prepend = $thisObj;
            }

            $thisObj.find('.js-open-popup').magnificPopup({
                fixedContentPos: option.fixedpos,
                closeBtnInside: false,
                prependTo:  prepend,
                mainClass: 'mfp-fade',
                focus: option.focus,
                gallery: {
                    enabled: option.gallery
                },

                image: {
                    verticalFit: option.verticalfit
                },

                iframe: {
                    patterns: {
                        youtube: {
                            src: 'https://www.youtube.com/embed/%id%?autoplay=1'
                        },

                        vimeo: {
                            src: 'https://player.vimeo.com/video/%id%?autoplay=1'
                        }
                    }
                },

                callbacks: {
                    open: function() {
                        this.content.find('.slide-slick').slick('refresh');
                        this.content.find('.slide-slick').slick('resize');
                    }
                }
            });
        });
    } catch(er) {console.log(er);}

    /*\
     *
     * select2
     *
    \*/
    try {
        $(".js-call-select2").each(function(){
            $(this).append('<span class="dropdown-select2"></span>');

            var $select = $(this).children('select');
            var $dropdown = $(this).children('.dropdown-select2');
            var style = 'default';
            var itemForSeach = 20;

            if($(this).data('style') != null) {
                style = $(this).data('style');
            }

            if($(this).data('itemforsearch') != null) {
                itemForSeach = $(this).data('itemforsearch');
            }

            $select.select2({
                minimumResultsForSearch: itemForSeach,
                dropdownParent: $dropdown,
                theme: style,
            });
        });
    } catch(er) {console.log(er);}

    /*\
     *
     * stickySidebar
     *
    \*/
    try {
        var offsetTop = $('html').offset().top + 10;
        var spacingTop = $('html').offset().top + 10;

        if($('.hun-header.style-sticky .element-for-stick').length) {
            offsetTop += $('.hun-header.style-sticky .element-for-stick').outerHeight();
        }

        $('.js-call-sticky-sidebar').each(function () {
            if ($(this).length > 0) {
                if ( $().theiaStickySidebar ) {
                    $(this).theiaStickySidebar({
                        'typeSticky'            : 1,
                        'spacingTopDefault'     : spacingTop,
                        'containerSelector'     : '',
                        'additionalMarginTop'   : offsetTop,
                        'additionalMarginBottom': 10,
                        'updateSidebarHeight'   : false,
                        'minWidth'              : 992,
                        'sidebarBehavior'       : 'modern',
                    });
                }
            }
        });
    } catch(er) {console.log(er);}

    /*\
     *
     * backToTop
     *
    \*/
    try {
        $('body').append(
            '<div class="btn-back-to-top">' +
            '<span class="symbol-btn">' +
            '</span>' +
            '</div>'
            )

        var $btnBackToTop = $('.btn-back-to-top');
        var windowH = $(window).height()/2;

        $(window).on('scroll',function(){
            if ($(this).scrollTop() > windowH) {
                $btnBackToTop.addClass('active-btn');
            } else {
                $btnBackToTop.removeClass('active-btn');
            }
        });

        $btnBackToTop.on("click", function(){
            $('html, body').animate({scrollTop: 0}, 1000);
        });

       /*---------------------------------------------*/
        if ($(window).outerWidth() < 992) {
            var hideIconTimeOut;
            var $btnBackToTopAutoHide = $('.btn-back-to-top.auto-hide');

            hideIcon();

            $(window).on('scroll', function() {
                if($btnBackToTopAutoHide.hasClass('hidden-btn')) {
                    clearTimeout(hideIconTimeOut);
                    $btnBackToTopAutoHide.removeClass('hidden-btn');
                    hideIcon();
                }
            });
        }

        function hideIcon() {
            hideIconTimeOut = setTimeout(function(){ 
                $btnBackToTopAutoHide.addClass('hidden-btn');
            }, 3000);
        }
    } catch(er) {console.log(er);}

    /*\
     *
     * preLoading
     *
    \*/
    try {
        $('.animsition').each(function() {
            var dataLoader = "spinner";

            $(this).animsition({
                inClass: 'fade-in',
                outClass: 'fade-out',
                inDuration: 1500,
                outDuration: 800,
                linkElement: '.animsition-link',
                loading: true,
                loadingParentElement: 'html',
                loadingClass: 'hun-pre-loading',
                loadingInner: '<div class="' + dataLoader + '"><span></span></div>',
                timeout: false,
                timeoutCountdown: 5000,
                onLoadEvent: true,
                browser: [ 'animation-duration', '-webkit-animation-duration'],
                overlay : false,
                overlayClass : 'animsition-overlay-slide',
                overlayParentElement : 'html',
                transition: function(url){ window.location.href = url; }
            });
        })
    } catch(er) {console.log(er);}

    /*\
     *
     * hunHeader
     *
    \*/
    // General
    try {
        var $header = $('.hun-header');
        var $menuMobile = $('.hun-menu-mobile');
        var $mainNavigation = $header.find('.main-navigation');
        var $mobileNavigation = $menuMobile.find('.mobile-navigation');
        var $listMenu = $mainNavigation.find('.list-menu');

        $mainNavigation.find('.list-menu li').each(function() {
            if($(this).children('.sub-menu').length > 0) {
                $(this).addClass('item-menu-has-children');
            }
        });

        $mobileNavigation.append($listMenu.clone());
    } catch(er) {console.log(er);}

    // Sticky
    try {
        var offsetTop = $('html').offset().top;
        var $topbar = $('.hun-topbar');
        var $headerSticky = $('.hun-header.style-sticky');
        var $elementForStick = $headerSticky.find('.element-for-stick');
        var latestScroll = 0; 

        if ($topbar.length) {
            $('.hun-header.style-overlay').css('top', $topbar.outerHeight() + 'px');
        }
        else {
            $('.hun-header.style-overlay').css('top', offsetTop + 'px');
        }

        if ($elementForStick.length > 0) {
            var posElement = $elementForStick.offset().top;
        }
        
        $elementForStick.css('top', - $elementForStick.outerHeight() - 30 + 'px');

        $(window).on('scroll', function() {
            var current = $(this).scrollTop();

            if (current > posElement + $elementForStick.outerHeight() - offsetTop) {
                $headerSticky.css('height', $headerSticky.outerHeight() + 'px');

                $headerSticky.addClass('fixed');
            } 
            else if (current <= posElement - offsetTop) {
                $headerSticky.removeClass('fixed');
                $elementForStick.css('top', - $elementForStick.outerHeight() - 30 + 'px');
                //$headerSticky.css('height', 'auto');
                setTimeout(function(){ 
                    $headerSticky.css('height', 'auto');
                }, 200);
            }

            if (current > latestScroll && current > posElement + $elementForStick.outerHeight() - offsetTop) {
                if (!$headerSticky.hasClass('menu-hide')) {
                    $headerSticky.addClass('menu-hide');
                    $elementForStick.css('top', - $elementForStick.outerHeight() - 10 + 'px');
                }
            } else {
                if ($headerSticky.hasClass('menu-hide')) {
                    $headerSticky.removeClass('menu-hide');
                    $elementForStick.css('top', offsetTop + 'px');
                }
            }

            latestScroll = current;
        });                
    } catch(er) {console.log(er);}

    // Responsive Sub-menu
    try {
        $(window).on('load',function(){
            responSubMenu();
        });

        $(window).on('resize',function(){
            responSubMenu();
        });

        var responSubMenu = function(){
            $('.hun-header .main-navigation .list-menu > li').each(function(){
                var $obj = $(this);
                var posRight = 0;
                var posRightSub = 0;
                var $deepestSubMenu = $obj.children('.sub-menu').children().children('.sub-menu');
                var numOfSubMenu = 1;

                while($deepestSubMenu.find('.sub-menu').length > 0) {
                    numOfSubMenu++;
                    $deepestSubMenu = $deepestSubMenu.find('.sub-menu');
                }

                if($obj.children('.sub-menu').length > 0) {
                    posRight = $obj.offset().left + $obj.children('.sub-menu').outerWidth();

                    if($deepestSubMenu.length > 0) {
                        posRightSub = posRight + $deepestSubMenu.outerWidth() * numOfSubMenu;
                    }
                }

                if(posRight >= $(window).width()) { 
                    var move = posRight - $(window).width();
                    $obj.children('.sub-menu').css('left', '-' + move + 'px');
                }
                else {
                    $obj.children('.sub-menu').css('left', '0');
                }

                if(posRightSub >= $(window).width()) { 
                    $obj.children('.sub-menu').find('.sub-menu').css({'left':'auto','right':'calc(100%)'});
                }
                else {
                    $obj.children('.sub-menu').find('.sub-menu').css({'right':'auto','left':'calc(100%)'});
                }
            });
        };
    } catch(er) {console.log(er);}
    
    // Mobile
    try {
        $('.hun-menu-mobile .list-menu li.item-menu-has-children').append('<span class="toggle-sub-menu"></span>');
        var $menuMobile = $('.hun-menu-mobile');
        var $btnToggle = $menuMobile.find('.btn-toggle-menu');
        var $toggleSubMenu = $menuMobile.find('.toggle-sub-menu');
        var $mobileNavigation = $menuMobile.find('.mobile-navigation');

        $btnToggle.on('click', function(e) {
            e.preventDefault();
            e.stopPropagation();

            if(!$menuMobile.hasClass('menu-mobile-active')) {
                $menuMobile.addClass('menu-mobile-active');
            }
            else {
                $menuMobile.removeClass('menu-mobile-active');
            }
        });

        $(document).on('click', function() {
            $menuMobile.removeClass('menu-mobile-active');
        });

        $toggleSubMenu.on('click', function() {
            if ($(this).prev('ul.sub-menu').is(':hidden')) {
                $(this).prev('ul.sub-menu').slideDown(200, 'linear');
                if(!$(this).hasClass('icon-up')) {
                    $(this).addClass('icon-up');
                }
            } 
            else {
                $(this).prev('ul.sub-menu').slideUp(200, 'linear');
                $(this).removeClass('icon-up');
            }
        });

        $mobileNavigation.on('click', function(e) {
            e.stopPropagation();
        })

        /*---------------------------------------------*/
        if ($(window).outerWidth() < 992) {
            var hideIconTimeOut;
            var $btnToggleAutoHide = $menuMobile.find('.btn-toggle-menu.auto-hide');

            hideIcon();

            $(window).on('scroll', function() {
                if($btnToggleAutoHide.hasClass('hidden-btn')) {
                    clearTimeout(hideIconTimeOut);
                    $btnToggleAutoHide.removeClass('hidden-btn');
                    hideIcon();
                }
            });
        }

        function hideIcon() {
            hideIconTimeOut = setTimeout(function(){ 
                $btnToggleAutoHide.addClass('hidden-btn');
            }, 3000);
        }
    } catch(er) {console.log(er);}

    /*\
     *
     * dateRangePicker
     *
    \*/
    try {
        $('.js-call-datepicker').each(function() {
            var dataDrop = 'down';
            var dropInside = $(this).data('drop-inside');
            var $parentDrop = $('body');

            if($(this).data('drop') != null) {
                dataDrop = $(this).data('drop');
            }

            if($(this).data('drop-inside')) {
                $parentDrop = $(this);
            }

            $(this).find('input').daterangepicker({
                parentEl: $parentDrop,
                singleDatePicker: true,
                showDropdowns: true,
                drops: dataDrop,
                locale: {
                    format: 'MM/DD/YYYY'
                },
            });
        })
    } catch(er) {console.log(er);}

    /*\
     *
     * Search
     *
    \*/
    try {
        var $eSearch = $('.hun-element-search');
        var $btnOpen = $eSearch.find('.search-open');
        var $btnClose = $eSearch.find('.search-close');
        var $searchForm = $eSearch.find('.search-form');
        var $searchField = $eSearch.find('.search-field');

        $btnOpen.on('click', function(){
            $searchForm.addClass('open');
            setTimeout(function() { $searchField.focus(); }, 800);
        });

        $btnClose.on('click', function(){
            $searchForm.removeClass('open');
        });

        $(window).on('keydown', function( event ) {
            if ( event.which === 27 ) {
                $searchForm.removeClass('open');
            }
        });
    } catch(er) {console.log(er);}

    /*\
     *
     * dropdown-menu
     *
    \*/
    try {
        var $eDropdownMenu = $('.hun-element-dropdown-menu');
        var $subMenu = $eDropdownMenu.find('.sub-menu');

        $subMenu.hide();

        $eDropdownMenu.on('click', function(e) {
            e.stopPropagation();
            var $thisSub = $(this).find('.sub-menu');
            $subMenu.not($thisSub).slideUp('fast');
            $thisSub.slideToggle('fast');
        });

        $(window).on('click', function() {
            $subMenu.slideUp('fast');
        })
    } catch(er) {console.log(er);}

    /*\
     *
     * Progress bar
     *
    \*/
    try {
        var $progressItem = $('.js-call-progress');
        
        $progressItem.find('.inner-progress').css('width', '0%');

        $(window).on('scroll load',function(){
            $progressItem.each(function(){
                var per = Number($(this).data('percent'));
                var $inner = $(this).find('.inner-progress');
                var $numProgress = $(this).find('.num-progress');

                if($(window).scrollTop() + $(window).height() > $(this).offset().top && per > 0) { 
                    $(this).data('percent','0');  
                    $inner.animate({width: per + "%"},20 * per);

                    var countPercent = 0;
                    var runPercent = setInterval(function(){ 
                        countPercent++;
                        $numProgress.html(countPercent);

                        if(countPercent === per) {
                            clearInterval(runPercent);
                        }
                    }, 20);
                }
            });
        });
    } catch(er) {console.log(er);}

    /*\
     *
     * Count Down
     *
    \*/
    try {
        $('.js-call-countdown').each(function() {
            var endYear = 0;
            var endMonth = 0;
            var endDate = 0;
            var endHours = 0;
            var endMinutes = 0;
            var endSeconds = 0;
            var myTimeZone = "";

            if($(this).data('year') != null) {
                endYear = $(this).data('year')
            }
            if($(this).data('month') != null) {
                endMonth = $(this).data('month')
            }
            if($(this).data('date') != null) {
                endDate = $(this).data('date')
            }
            if($(this).data('hours') != null) {
                endHours = $(this).data('hours')
            }
            if($(this).data('minute') != null) {
                endMinutes = $(this).data('minute')
            }
            if($(this).data('second') != null) {
                endSeconds = $(this).data('second')
            }
            if($(this).data('timezone') != null) {
                myTimeZone = $(this).data('timezone')
            }

            $(this).countdown100({
                /*Set Endtime here*/
                /*Endtime must be > current time*/
                endtimeYear: endYear,
                endtimeMonth: endMonth,
                endtimeDate: endDate,
                endtimeHours: endHours,
                endtimeMinutes: endMinutes,
                endtimeSeconds: endSeconds,
                timeZone: myTimeZone
                // ex:  timeZone: "America/New_York"
                //go to " http://momentjs.com/timezone/ " to get timezone
            });
        });

    } catch(er) {console.log(er);}

})(jQuery);