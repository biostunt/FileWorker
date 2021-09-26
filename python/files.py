import os


def file_exists(path: str) -> bool:
    return os.path.isfile(path)


def create_file(path: str, *lines: 'list[str]') -> None:
    with open(path, 'w') as file:
        file.write("-".join(lines))
        file.close()


def append_file(path: str, *lines: 'list[str]') -> None:
    with open(path, 'a') as file:
        file.write('-'.join(lines))
        file.close()


def read_file(path: str) -> 'list[str]':
    with open(path, 'r') as file:
        lines = file.readlines()
        file.close()
        return lines


def delete_file(path: str) -> None:
    os.remove(path)
