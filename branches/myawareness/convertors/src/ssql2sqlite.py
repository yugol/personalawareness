noteList = []
noteOffset = 101

groupList = []
groupOffset = 6

accList = []
accOffset = 10

itemList = []
itemOffset = 1

trList = []

def splitValues(line):
    values = []
    start = line.find('(', line.find('(', ) + 1)
    for value in line[start + 1 : len(line) - 2].split(','):
        values.append(value.strip())
    return values  

def convertStr(str):
    if (str == "NULL"):
        return str
    str = str.replace(" + NCHAR(13) + N'' + NCHAR(10)", "")
    str = str.replace("' + N'", " ")
    return str[1:]

def process(fileName):
    file = open(fileName)
    for line in file.readlines():
        line = line.strip()
        if line.find("notes") >= 0:
            readNote(line)
        elif line.find("account_types") >= 0:
            readGroup(line)
        elif line.find("transfer_locations") >= 0:
            readAcc(line)
        elif line.find("transaction_reasons") >= 0:
            readItem(line)
        elif line.find("transactions") >= 0:
            readTr(line)
    file.close()
    
    writeAccList()
    writeItemList()
    writeTrList()
    
def readNote(line):
    noteList.append(' + '.join(splitValues(line)[5:]))

def readGroup(line):
    groupList.append(splitValues(line)[0])

def readAcc(line):
    accList.append(splitValues(line))
    
def readItem(line):
    itemList.append(splitValues(line)[1])

def readTr(line):
    trList.append(splitValues(line))
    
def writeAccList():
    for acc in accList:
        #print acc
        
        name = acc[2]
        type = "1"
        group = "NULL"
        ival = "0.00"
        desc = "NULL"

        acc0 = int(acc[0])
        acc1 = int(acc[1])
        if (1 == acc0):
            if (0 == acc1):
                type = "0"
            else:
                type = "2"
        
            acc3 = int(acc[3])
            if (1 != acc3):
                desc = noteList[acc3 - noteOffset]
        else:
            group = groupList[acc1 - groupOffset]
            ival = str(acc[3])
            
            acc4 = int(acc[4])
            if (1 != acc4):
                desc = noteList[acc4 - noteOffset]
                
        name = convertStr(name)
        group = convertStr(group)
        desc = convertStr(desc)

        print "INSERT INTO accounts (type, ival, name, [group], [desc]) VALUES (",
        print ", ".join((type, ival, name, group, desc)),
        print ");"

def writeItemList():
    for item in itemList:
        name = convertStr(item)
        print "INSERT INTO items (name) VALUES (", name, ");"    
    
def writeTrList():
    for tr in trList:
        from_ = int(tr[1]) - accOffset
        if (from_ <= 0):
            continue
        from_ = str(from_)
        to_ = str(int(tr[2]) - accOffset)
        date = tr[0].replace("-", "")
        item = tr[3]
        val = tr[4]
        
        tr6 = int(tr[6])
        if (1 == tr6):
            desc = "NULL"
        else:
            desc = noteList[tr6 - noteOffset]
            desc = convertStr(desc)
        
        print "INSERT INTO transactions ([date], val, [from], [to], item, [desc]) VALUES (",
        print ", ".join((date, val, from_, to_, item, desc)),
        print ");"
    

if __name__ == '__main__':
    fileName = '../data/2010-06-27.ssql'
    process(fileName)
