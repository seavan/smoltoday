﻿/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.language = 'ru';

    // Toolbar configuration generated automatically by the editor based on config.toolbarGroups.
    config.toolbar = [
	{ name: 'document', groups: ['mode', 'document', 'doctools'], items: ['Source', '-', 'Save', 'NewPage', 'Preview', 'Print', '-', 'Templates'] },
	{ name: 'clipboard', groups: ['clipboard', 'undo'], items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
	{ name: 'editing', groups: ['find', 'selection', 'spellchecker'], items: ['Find', 'Replace', '-', 'SelectAll', '-', 'Scayt'] },
	{ name: 'forms', items: ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'] },
	'/',
	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'], items: ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'] },
	{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'], items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'] },
	{ name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
	{ name: 'insert', items: ['Image', 'Flash', 'MediaEmbed', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe'] },
	'/',
	{ name: 'styles', items: ['Styles', 'Format'] },
	{ name: 'colors', items: ['TextColor', 'BGColor'] },
	{ name: 'tools', items: ['Maximize', 'ShowBlocks'] },
	{ name: 'others', items: ['-'] },
	{ name: 'about', items: ['About'] }
];

    // Toolbar groups configuration.
    config.toolbarGroups = [
	{ name: 'document', groups: ['mode', 'document', 'doctools'] },
	{ name: 'clipboard', groups: ['clipboard', 'undo'] },
	{ name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
	{ name: 'forms' },
	'/',
	{ name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
	{ name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
	{ name: 'links' },
	{ name: 'insert' },
	'/',
	{ name: 'styles' },
	{ name: 'colors' },
	{ name: 'tools' },
	{ name: 'others' },
	{ name: 'about' }
];
    /* config.toolbar =
    [
    ['Source', '-', 'Bold', 'Italic', '-', 'Link', 'Unlink', '-', 'MediaEmbed', 'Image', 'Table', '-', 'PasteFromWord'],
    ['UIColor']
    ];*/
    config.extraPlugins = 'MediaEmbed,onchange';

    config.filebrowserImageUploadUrl = '/NewsAdmin/Upload';

    config.height = '400px';

    config.width = '900px';

    config.enterMode = 'p';
};
