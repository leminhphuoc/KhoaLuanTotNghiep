/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

enterMode: CKEDITOR.ENTER_P,

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Asset/Admin/js/Plugin/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Asset/Admin/js/Plugin/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Asset/Admin/js/Plugin/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Asset/Admin/js/Plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data1';
    config.filebrowserFlashUploadUrl = '/Asset/Admin/js/Plugin/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    CKFinder.setupCKEditor(null, '/Asset/Admin/js/Plugin/ckfinder/');
    config.enterMode = CKEDITOR.ENTER_BR;
    config.shiftEnterMode = CKEDITOR.ENTER_P;
    enterMode: CKEDITOR.ENTER_P;
};
