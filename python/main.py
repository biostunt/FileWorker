from parser_generator import create_parser
from schema import get_schema
import sys


args = create_parser().parse_args().__dict__
print(create_parser().parse_args())
schema = get_schema()
for key in args:
    if args[key]:
        try:
            if type(args[key]) == bool:
                schema[key]()    
            else:
                schema[key](*args[key])
            sys.exit(0)
        except Exception as err:
            print(err)
            sys.exit(1)
