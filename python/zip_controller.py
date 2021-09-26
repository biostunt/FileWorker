from files import delete_file, file_exists
from zipfile import ZipFile


def create_zip(path: str):
  if file_exists(path):
    raise Exception(f'Object on path {path} already exists')
  zip = ZipFile(path, 'w')
  zip.close()

def add_to_archive(path: str, *files: 'list[str]') -> None:
  if not file_exists(path):
    raise Exception(f'File not found')
  zip = ZipFile(path, 'w')
  for file in files:
    if file_exists(file):
      zip.write(file)
  zip.close()

def unzip_zip(zip_path: str, dir_path: str) -> None:
  with ZipFile(zip_path, 'r') as zip:
    zip.extractall(dir_path)

def delete_zip(path: str) -> None:
  delete_file(path)

controller_schema = {
  'create_zip': create_zip,
  'append_zip': add_to_archive,
  'unzip_zip': unzip_zip,
  'delete_zip': delete_zip
}