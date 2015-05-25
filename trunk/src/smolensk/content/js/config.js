/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.language = 'ru';


    config.toolbar =
    [
        ['Source', '-', 'Bold', 'Italic', '-', 'RemoveFormat', '-', 'Link', 'Unlink', '-', 'MediaEmbed', 'Image', 'Table', '-', 'PasteFromWord'],
        ['UIColor']
    ];
    config.extraPlugins = 'MediaEmbed';

    config.filebrowserImageUploadUrl = '/Profile/Upload';

    config.removeFormatAttributes = 'class,style,lang,width,height,align,hspace,valign';
    config.removeFormatTags = 'b,big,code,del,dfn,em,font,i,ins,kbd,q,samp,small,span,strike,strong,sub,sup,tt,u,var,span,div,h1,h2,h3,h4,h5,h6,ol,ul,li,dl,dt,dd';

    config.height = '350px';

    config.width = '618px';
};
