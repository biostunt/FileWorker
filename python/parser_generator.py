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

  return parser