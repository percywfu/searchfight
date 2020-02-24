import sys
import requests

def search(keyWords, KEY, EngineID):
    url = "https://www.googleapis.com/customsearch/v1?key="+KEY+"&cx="+EngineID+"&q="+keyWords
    response = requests.get(url)
    resJson = response.json()
    return (resJson['queries']['request'][0]['totalResults'])

def getResults(keyWords):
    EngineIdGoogle = "004432549449583349288:nalrskjiw5l"
    EngineIdBing = "004432549449583349288:dzujar3pgzy"
    KEY = "AIzaSyDZ9Xp_pjTaqR7-9KwUaRrZtPJPloRXZ6E"

    resGoogle = search(keyWords, KEY, EngineIdGoogle)
    resBing = search(keyWords, KEY, EngineIdBing)

    return [resBing, resGoogle]
   
if __name__ == "__main__":
    # getting parameters from console
    keyWordss = sys.argv[1:]
    if len(keyWordss) == 0:
        print('nothing to search')
    else:
        contGoogle = 0
        contBing = 0
        for keyWords in keyWordss:
            result = getResults(keyWords)
            print("______________________________________________")
            print('{}: Bing   => {}'.format(keyWords,result[0]))
            print('{}: Google => {}'.format(keyWords,result[1]))
            if result[0]>result[1]:
                contBing += 1
                print('{} Bing Winner'.format(keyWords))
            elif result[0]<result[1]:
                contGoogle += 1
                print('{} Google Winner'.format(keyWords))
        print("______________________________________________")
        print('Total results: Google {} vs Bing {}'.format(contGoogle,contBing))
        if contGoogle>contBing:
            print('Total results: Google winner')
        elif contGoogle<contBing:
            print('Total results: Bing winner')