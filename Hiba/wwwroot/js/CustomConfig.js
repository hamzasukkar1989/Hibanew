/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
 
    config.language = 'en';
    config.filebrowserUploadUrl = '/News/UploadImage';
    
    config.allowedContent = true;
    config.toolbarCanCollapse = true;
    config.filebrowserUploadMethod = 'form';
  
    config.removeButtons = 'Source,Checkbox,ImageButton,Anchor,Radio,Save,Flash,Form,TextField,Textarea,Button,CreateDiv,Select,About,HiddenField,IFrame';
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
 
   
 
