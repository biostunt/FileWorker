import subprocess

def get_drive_info(*drive_raw: 'list[str]') -> None:
  drive_name = ''.join(drive_raw)
  process = subprocess.Popen(['df', '-h'], stdout=subprocess.PIPE)
  out, err = process.communicate()
  sys_call_out = out.splitlines()[1:]
  if err: 
    print(err)
  for line in sys_call_out:
    tmp = [str(s) for s in str(line).split(' ') if len(s) != 0]
    #hint to filter strings 
    tmp[0] = tmp[0][2:len(tmp[0])]
    tmp[-1] = tmp[-1][0:len(tmp[-1])-1]
    if drive_name == 'None' or drive_name == tmp[-1]:    
      print(f'Drive name: {tmp[-1]}')
      print(f'Usage: {tmp[-2]}')
      print(f'Total size: {tmp[1]}')
      print(f'Empty space: {tmp[3]}')
      print(f'Label: {tmp[0]}')
      print()


def get_drive_list() -> None:
  get_drive_info(*'None'.split())


controller_schema = {
  'drive_info': get_drive_info,
  'drive_list': get_drive_list
}