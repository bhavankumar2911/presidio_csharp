from operator import itemgetter

players = [
    {
        "name" : "Alex",
        "score" : 23
    },
    {
        "name" : "Zyan",
        "score" : 234
    },
    {
        "name" : "Bhavan",
        "score" : 214
    },
    {
        "name" : "Ritika",
        "score" : 983
    },
    {
        "name" : "Gayatri",
        "score" : 287
    },
    {
        "name" : "Arvind",
        "score" : 724
    },
    {
        "name" : "Kavin",
        "score" : 981
    },
    {
        "name" : "Huzzair",
        "score" : 87
    },
    {
        "name" : "Aslam",
        "score" : 723
    },
    {
        "name" : "Sena",
        "score" : 343
    },
    {
        "name" : "Sukesh",
        "score" : 982
    },
    {
        "name" : "Harsha",
        "score" : 98
    },
]

# players = sorted(players, key=itemgetter("score", "name"))
players = sorted(players, key = lambda k: (-k["score"], k["name"]))

for i in range(10):
    print(players[i])