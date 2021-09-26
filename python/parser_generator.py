from argparse import ArgumentParser
from file_controller import append_file, create_file, delete_file, read_file


def create_parser() -> ArgumentParser:
  parser = ArgumentParser(prog='File Worker',description='Not for file, but for soul')

  parser.add_argument('-cf', '--create-file', 
    nargs=1,  
    metavar='<file_path>', 
    help='Create a file by provided path')
  
  parser.add_argument('-af', '--append-file', 
    nargs=2,  
    metavar=('<file_path>', '<some_data>'), 
    dest="append_file",
    help='Append a file by provided path')
  
  parser.add_argument('-rf', '--read-file', 
    nargs=1, 
    metavar='<file_path>', 
    help='Read a file by provided path')

  parser.add_argument('-df', '--delete-file', 
    nargs=1, 
    metavar='<file_path>', 
    help='Remove a file by provided path')

  parser.add_argument('-dj', '--delete-json', 
    nargs=1, 
    metavar='<json_file_path>', 
    help='Remove a file by provided path')

  parser.add_argument('-rj', '--read-json', 
    nargs=1, 
    metavar='<json_file_path>', 
    help='Read a json file by provided path')
  
  parser.add_argument('-ctj', '--create-template-json', 
    nargs=1, 
    metavar='<json_file_path>', 
    help='Create a json template file by provided path')

  parser.add_argument('-cj', '--create-json', 
    nargs=2, 
    metavar=('<json_file_path>', '<json_object>'), 
    help='Create a json file by provided path and provided object')
  
  parser.add_argument('-ctx', '--create-template-xml', 
    nargs=1, 
    metavar='<json_file_path>', 
    help='Create xml template file by provided path')
  
  parser.add_argument('-cx', '--create-xml', 
    nargs=2, 
    metavar=('<xml_file_path>', '<xml_object>',), 
    help='Create xml template file by provided path and provided object')
  
  parser.add_argument('-rx', '--read-xml', 
    nargs=1, 
    metavar='<xml_file_path>', 
    help='read xml file by provided path')


  parser.add_argument('-dx', '--delete-xml', 
    nargs=1, 
    metavar='<xml_file_path>', 
    help='delete xml file by provided path')

  parser.add_argument('-cz', '--create-zip', 
    nargs=1, 
    metavar='<zip_file_path>', 
    help='create zip file by provided path')

  parser.add_argument('-az', '--append-zip', 
    nargs=2, 
    metavar=('<zip_file_path>', '<file_path>'),
    help='append zip file by provided path and provided filepath')
  
  parser.add_argument('-uz', '--unzip-zip', 
      nargs=2, 
      metavar=('<zip_file_path>', '<unzip_path>'), 
      help='unzip file by provided path')
    
  parser.add_argument('-dz', '--delete-zip', 
      nargs=1,
      metavar='<zip_file_path>', 
      help='delete zip file by provided path')
  
  parser.add_argument('-di', '--drive-info',
    nargs=1,
    metavar='<drive_name>',
    help='get drive information'
  )

  parser.add_argument('-dl', '--drive-list',
    action='store_true',
    help='get drive information'
  )
  return parser