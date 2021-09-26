from files import read_file, file_exists, delete_file
import xml.etree.ElementTree as ET
import json

def create_template_xml(path: str) -> None:
  if file_exists(path):
    raise Exception(f'File with path {path} already exists!')
  root = ET.Element('root')
  person = ET.SubElement(root, 'person')
  ET.SubElement(person, 'id').text = '1'
  ET.SubElement(person, 'name').text = 'some strange name'
  ET.SubElement(person, 'roles').text = json.dumps(['ADMIN'])
  tree = ET.ElementTree(root)
  tree.write(path)

def create_xml(path: str, *data: 'list[str]') -> None:
  if file_exists(path):
    raise Exception(f'File already exists!')
  root = ET.fromstring(''.join(data))
  tree = ET.ElementTree(root)
  tree.write(path)

def read_xml(path: str) -> None:
  if not file_exists(path):
    raise Exception(f'No file with path {path} found')
  tree = ET.fromstring(''.join(read_file(path)))
  ET.dump(tree)

def delete_xml(path: str) -> None:
  delete_file(path)

controller_schema = {
  'create_template_xml': create_template_xml,
  'create_xml': create_xml,
  'read_xml': read_xml,
  'delete_xml': delete_xml,
}