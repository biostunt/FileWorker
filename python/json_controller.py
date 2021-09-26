from files import file_exists
from file_controller import delete_file
import json

def delete_json (path: str) -> None:
    delete_file(path)

def read_file(path: str) -> None:
    if not file_exists(path):
        raise Exception(f'File with name {path} not found')
    with open(path) as file:
        print(json.load(file))

def create_template_json(path: str) -> None:
    if file_exists(path):
        raise Exception(f'File with name {path} already exists')
    template = {
        'id': 1,
        'name': 'Ivan',
        'roles': ['ADMIN', 'MODERATOR']
    }
    with open(path, 'w') as file:
        json.dump(template, file)

def create_json_object(path: str, *data: 'list[str]') -> None:
    if file_exists(path):
        raise Exception(f'File with name {path} already exists')
    try:
        curr_json = json.loads(''.join(data))
        with open(path, 'w') as file:
            json.dump(curr_json, file)
    except:
        print('Error while reading json')

controller_schema = {
    'read_json' : read_file,
    'delete_json': delete_json,
    'create_template_json': create_template_json,
    'create_json': create_json_object,
}