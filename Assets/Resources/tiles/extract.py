import re
import xml.etree.ElementTree as ET 

tree = ET.parse("tiles_spritesheet.xml") 
root = tree.getroot() 

items = [ 'unknown' ]

for item in root.findall('./SubTexture'): 
  x = item.attrib['x']
  y = item.attrib['y']
  width = item.attrib['width']
  height = item.attrib['height']
  name = item.attrib['name'].split('.')[0];
  items.append(name)
  print ("items[(int)ObjType.%s] = new int [] {%s, %s, %s, %s};" % (name, x, y, width, height))

# print(items)

# public enum ObjType : int
for item in items:
  print(item + ',')

print(len(items))