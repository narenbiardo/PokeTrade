import subprocess

getPKInfo = subprocess.run(
    [
        ".\\Bin\\TradePK6ToPK6.exe",
        "getPKInfo",
        ".\\Shared\\insert.pk1",
    ],
    stdout=subprocess.PIPE,
)
output = getPKInfo.stdout.decode("utf-8")
print(output)

"""
new
print("Transferir PK6 a PK6")
result = subprocess.run(
    [
        ".\\Bin\\TradePK6ToPK6.exe",
        "tradePKToSAV",
        ".\\Shared\\sav",
        ".\\Shared\\insert.pk6",
        ".\\Shared\\remove.pk6",
    ], stdout=subprocess.PIPE
)
output = result.stdout.decode('utf-8')
print("Convertir PK")
subprocess.run(
    [
        ".\\Bin\\TradePK6ToPK6.exe",
        "convertPK",
        "..\Shared\convert.pk5",
        "6",
    ], stdout=subprocess.PIPE
)
"""

"""
old

os.chdir(".\Bin")

os.chdir(".\Bin")
subprocess.run([".\TradePK6ToPK6.exe", "..\Shared\sav", "..\Shared\insert.pk6", "..\Shared\remove.pk6"])
"""
