from file_controller import controller_shema as file_shema


shemas = [file_shema]


def get_shema() -> 'dict(str, function)':
    temp = {}
    for shema in shemas:
        for key in shema:
            temp[key] = shema[key]
    return temp
