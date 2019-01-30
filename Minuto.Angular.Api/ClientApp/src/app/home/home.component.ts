import { Component } from '@angular/core';
import { FeedService } from '../../../services/feeds.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  feeds: any[];
  topWords: any[];
  constructor(feedService: FeedService) {

    feedService.GetFeeds().subscribe(feedList => {
      this.feeds = feedList;
     });

     feedService.GetTopWordFromTopic().subscribe(feedList => {
      this.topWords = feedList;
     });
  }
}

