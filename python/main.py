from parser_generator import create_parser
from shema import get_shema
import sys

args = create_parser().parse_args().__dict__
shema = get_shema()
for key in args:
    if args[key]:
        try:
            shema[key](*args[key])
            sys.exit(0)
        except Exception as err:
            print(err)
            sys.exit(1)
