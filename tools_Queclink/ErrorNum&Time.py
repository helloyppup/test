import time,fileinput,os,re
from datetime import datetime,date

file_name="UDP_20789_20230222.txt"

def ReadFile(file_name):
    """
    获取文件文本
    :param file_name: string类型 要读取的文本名
    :return:返回一个列表，每一行作为一个元素
    """
    file = open(file_name, "r", encoding="utf-8")
    txt=[]
    for line in file:
        txt.append(line.strip(" "))
    file.close()
    return txt

def SliceLine(txt):
    """
    切割每行的元素
    :param txt: 文本
    :return: 文本切割后的列表 结构为[[每一行文本[文本内分割单元]][][]]
    """
    line_unitys=[]
    for line in txt:
        if(line!="\n"  and "ASC" in line):
            line_unity=line.split(',')
            line_unitys.append(line_unity)
    return  line_unitys

def SliceLineOne(line):
    lines=line.split(',')
    return lines

def GetNums(line_unitys):
    lines=[]
    nums=[]
    for theLines in line_unitys:
            lines.append(theLines[-1])
    for line in lines:
        nums.append(int(line[0:4],16))
    return  nums


def GetTime(date_time_str):
    return datetime.strptime(date_time_str, "%Y%m%d%H%M%S")

def Save(file_name,data):
    file=open(file_name,'a')
    file.write(data)
    file.close()

class TimeAndIndex:
    time

    def __init__(self,time,index,type):
        self.time=time

    def TimeDiff(self,endTime):
        """
         返回一个以分钟为单位的时间差
        :param endTime:
        :return:
        """
        endTime=GetTime(endTime)
        time=GetTime(self.time)
        return (endTime - time).seconds // 60

def TimeDiff(stratTime,endTime):
    #endTime = GetTime(endTime)
    #time = GetTime(stratTime)

    return (endTime-stratTime).seconds//60

def ErrorTime():

    report_type="GTDMR"
    txt=ReadFile(file_name)
    index=0
    timeOffset=60
    Inaccuray=1

    line_unitys = SliceLine(txt)
    report_type_unitys=[]

    #获取时间列表
    times=[]
    for line in txt:
        if(report_type in line):
            report_type_unitys.append(SliceLineOne(line))
    for line in report_type_unitys:
        times.append(GetTime(line[-2]))

    while 1:
        timeDiff=TimeDiff(times[index],times[index+1])
        if  abs(timeDiff-timeOffset)>Inaccuray:
            #timeOffset!=timeDiff:
            str1 = ",".join(report_type_unitys[index])
            str2 = ",".join(report_type_unitys[index + 1])

            data=str1+str2+"--timeDiff:"+str(timeDiff)+" min\n\n"
            Save("异常时间_"+"_"+report_type+"_"+file_name,data)

        index+=1
        if index + 1 > len(times) -1:
            break


def ErrorNum():
    txt = ReadFile(file_name)
    long=1
    index=0
    # 获取列表
    line_unitys=SliceLine(txt)
    nums=GetNums(line_unitys)


    while 1:
        numDiff=nums[index+1]-nums[index]
        if  numDiff!=long:
            str1=",".join(line_unitys[index])
            str2=",".join(line_unitys[index+1])

            data=str1+str2+"--numDiff:"+str(numDiff)+"\n\n"
            Save("异常序列号_"+"_"+file_name,data)

        index+=1
        if index +1 > len(nums) -1:
            break

ErrorNum()
ErrorTime()