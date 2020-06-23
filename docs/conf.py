from recommonmark.parser import CommonMarkParser
source_parsers = {
'.md': CommonMarkParser,
}
source_suffix = ['.rst', '.md']
master_doc = 'index' 
project = u'Scryber Core'
html_static_path = ['_static']

html_style = 'css/scrybertheme.css'
