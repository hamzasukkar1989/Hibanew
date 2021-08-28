/**
 * @license Copyright (c) 2003-2021, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	//config.removeDialogTabs = 'image:advanced;image:Link;link:advanced;link:upload';
	config.filebrowserImageUploadUrl = '/Home/UploadImage' //Action for Uploding image 
	config.filebrowserUploadUrl = '/Home/UploadImage';
	config.filebrowserUploadMethod = 'form';
};
CKEDITOR.on('dialogDefinition', function (ev) {
    var dialogName = ev.data.name;
    var dialogDefinition = ev.data.definition;

    if (dialogName === 'table') {
        var infoTab = dialogDefinition.getContents('info');
        var cellSpacing = infoTab.get('txtCellSpace');
        cellSpacing['default'] = "0";
        var cellPadding = infoTab.get('txtCellPad');
        cellPadding['default'] = "0";
        // var border = infoTab.get('txtBorder');
        // border['default'] = "0";
    }

});