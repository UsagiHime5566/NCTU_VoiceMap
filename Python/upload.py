import requests

test_file = open("qoo.mp4", "rb")
print('open')
test_url = "http://220.133.215.118/public/imgupload.php"

test_response = requests.post(test_url, files={"file": test_file})

if test_response.ok:
    print("upload completed successfully")
    print(test_response.text)
else:
    print(test_response.text)