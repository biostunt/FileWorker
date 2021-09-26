import files


def create_file(path: str) -> None:
    if files.file_exists(path):
        raise Exception(f'File with name {path} already exists')
    files.create_file(path)


def append_file(path: str, *values: 'list[str]') -> None:
    if not files.file_exists(path):
        raise Exception(f'File with name {path} not found')
    files.append_file(path, *values)


def read_file(path: str) -> None:
    if not files.file_exists(path):
        raise Exception(f'File with name {path} not found')
    str = files.read_file(path)
    print(str)


def delete_file(path: str) -> None:
    files.delete_file(path)


controller_schema: 'dict[str, function]' = {
    'read_file': read_file,
    'create_file': create_file,
    'delete_file': delete_file,
    'append_file': append_file
}
