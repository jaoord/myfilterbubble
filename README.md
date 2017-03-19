# Readme #

- download news from rss feed, save into db
- analyze and categorize text 
- show news that the user probably will like on web page and let user read it
- user can like or dislike news.
    - when user likes the news, nothing is done, save like in db.
    - when user dislikes the news, save dislike in db.
- user can also read news that was categorized as probably uninteresting, and rate that
- user can also read the news that couldn't get categorized.
- every once in a while, the bayesean databases are cleared and news from the database is 
  read into the like or dislike database, based on what the use chose.
- repeat from step 1.