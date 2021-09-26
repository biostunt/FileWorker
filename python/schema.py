from file_controller import controller_schema as file_schema
from json_controller import controller_schema as json_schema
from xml_controller import controller_schema as xml_schema
from zip_controller import controller_schema as zip_schema
from drive_controller import controller_schema as drive_schema

schemas = [
    file_schema, 
    json_schema, 
    xml_schema,
    zip_schema,
    drive_schema
]


def get_schema() -> 'dict(str, function)':
    temp = {}
    for schema in schemas:
        for key in schema:
            temp[key] = schema[key]
    return temp
