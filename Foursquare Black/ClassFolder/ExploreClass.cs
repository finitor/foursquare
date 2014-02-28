﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foursquare_Black.ClassFolder
{
    class ExploreClass
    {
        public class Meta
        {
            public int code { get; set; }
        }

        public class Item
        {
            public int unreadCount { get; set; }
        }

        public class Notification
        {
            public string type { get; set; }
            public Item item { get; set; }
        }

        public class Filter
        {
            public string name { get; set; }
            public string key { get; set; }
        }

        public class SuggestedFilters
        {
            public string header { get; set; }
            public List<Filter> filters { get; set; }
        }

        public class Ne
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Sw
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class SuggestedBounds
        {
            public Ne ne { get; set; }
            public Sw sw { get; set; }
        }

        public class Reasons
        {
            public int count { get; set; }
            public List<object> items { get; set; }
        }

        public class Photo
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class User
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string relationship { get; set; }
            public Photo photo { get; set; }
        }

        public class Item4
        {
            public int visitedCount { get; set; }
            public bool liked { get; set; }
            public bool disliked { get; set; }
            public User user { get; set; }
            public int? photos { get; set; }
        }

        public class FacePile
        {
            public int count { get; set; }
            public List<Item4> items { get; set; }
        }

        public class Reason
        {
            public string text { get; set; }
            public FacePile facePile { get; set; }
        }

        public class Item3
        {
            public Reason reason { get; set; }
        }

        public class Snippets
        {
            public int count { get; set; }
            public List<Item3> items { get; set; }
        }

        public class Contact
        {
            public string phone { get; set; }
            public string formattedPhone { get; set; }
            public string twitter { get; set; }
            public string facebook { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public string crossStreet { get; set; }
            public double lat { get; set; }
            public double lng { get; set; }
            public int distance { get; set; }
            public string postalCode { get; set; }
            public string cc { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string country { get; set; }
        }

        public class Icon
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
            public string pluralName { get; set; }
            public string shortName { get; set; }
            public Icon icon { get; set; }
            public bool primary { get; set; }
        }

        public class Stats
        {
            public int checkinsCount { get; set; }
            public int usersCount { get; set; }
            public int tipCount { get; set; }
        }

        public class Group2
        {
            public string type { get; set; }
            public int count { get; set; }
            public List<object> items { get; set; }
        }

        public class Likes
        {
            public int count { get; set; }
            public List<Group2> groups { get; set; }
            public string summary { get; set; }
        }

        public class Hours
        {
            public bool isOpen { get; set; }
            public string status { get; set; }
        }

        public class Specials
        {
            public int count { get; set; }
            public List<object> items { get; set; }
        }

        public class Photos
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
        }

        public class HereNow
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
        }

        public class Menu
        {
            public string type { get; set; }
            public string label { get; set; }
            public string anchor { get; set; }
            public string url { get; set; }
            public string mobileUrl { get; set; }
        }

        public class VenuePage
        {
            public string id { get; set; }
        }

        public class Price
        {
            public int tier { get; set; }
            public string message { get; set; }
            public string currency { get; set; }
        }

        public class Reservations
        {
            public string url { get; set; }
        }

        public class BeenHere
        {
            public int count { get; set; }
            public bool marked { get; set; }
        }

        public class Events
        {
            public int count { get; set; }
            public string summary { get; set; }
        }

        public class Provider
        {
            public string name { get; set; }
        }

        public class Delivery
        {
            public string url { get; set; }
            public Provider provider { get; set; }
        }

        public class Photo2
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class Followers
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
        }

        public class Tips
        {
            public int count { get; set; }
        }

        public class Contact2
        {
            public string twitter { get; set; }
        }

        public class Page
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string gender { get; set; }
            public Photo2 photo { get; set; }
            public string type { get; set; }
            public Followers followers { get; set; }
            public Tips tips { get; set; }
            public string homeCity { get; set; }
            public string bio { get; set; }
            public Contact2 contact { get; set; }
        }

        public class Photo3
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class User2
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string gender { get; set; }
            public Photo3 photo { get; set; }
            public string type { get; set; }
        }

        public class Item6
        {
            public string id { get; set; }
            public int createdAt { get; set; }
            public string prefix { get; set; }
            public string suffix { get; set; }
            public int width { get; set; }
            public int height { get; set; }
            public User2 user { get; set; }
            public string visibility { get; set; }
        }

        public class Photos2
        {
            public int count { get; set; }
            public List<Item6> items { get; set; }
        }

        public class Item5
        {
            public string id { get; set; }
            public int createdAt { get; set; }
            public Page page { get; set; }
            public string shout { get; set; }
            public List<object> entities { get; set; }
            public Photos2 photos { get; set; }
            public bool logView { get; set; }
        }

        public class PageUpdates
        {
            public int count { get; set; }
            public List<Item5> items { get; set; }
        }

        public class Venue
        {
            public string id { get; set; }
            public string name { get; set; }
            public Contact contact { get; set; }
            public Location location { get; set; }
            public List<Category> categories { get; set; }
            public bool verified { get; set; }
            public Stats stats { get; set; }
            public string url { get; set; }
            public Likes likes { get; set; }
            public bool like { get; set; }
            public double rating { get; set; }
            public Hours hours { get; set; }
            public Specials specials { get; set; }
            public Photos photos { get; set; }
            public HereNow hereNow { get; set; }
            public Menu menu { get; set; }
            public VenuePage venuePage { get; set; }
            public string storeId { get; set; }
            public Price price { get; set; }
            public Reservations reservations { get; set; }
            public BeenHere beenHere { get; set; }
            public Events events { get; set; }
            public Delivery delivery { get; set; }
            public PageUpdates pageUpdates { get; set; }
        }

        public class Likes2
        {
            public int count { get; set; }
            public List<object> groups { get; set; }
            public string summary { get; set; }
        }

        public class Todo
        {
            public int count { get; set; }
        }

        public class Photo4
        {
            public string prefix { get; set; }
            public string suffix { get; set; }
        }

        public class User3
        {
            public string id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public Photo4 photo { get; set; }
            public string type { get; set; }
        }

        public class Source
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Photo5
        {
            public string id { get; set; }
            public int createdAt { get; set; }
            public Source source { get; set; }
            public string prefix { get; set; }
            public string suffix { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Tip
        {
            public string id { get; set; }
            public int createdAt { get; set; }
            public string text { get; set; }
            public string canonicalUrl { get; set; }
            public Likes2 likes { get; set; }
            public bool logView { get; set; }
            public Todo todo { get; set; }
            public User3 user { get; set; }
            public string url { get; set; }
            public Photo5 photo { get; set; }
            public string photourl { get; set; }
        }

        public class Flags
        {
            public bool outsideRadius { get; set; }
        }

        public class Item2
        {
            public Reasons reasons { get; set; }
            public Snippets snippets { get; set; }
            public Venue venue { get; set; }
            public List<Tip> tips { get; set; }
            public string referralId { get; set; }
            public Flags flags { get; set; }
        }

        public class Group
        {
            public string type { get; set; }
            public string name { get; set; }
            public List<Item2> items { get; set; }
        }

        public class Response
        {
            public SuggestedFilters suggestedFilters { get; set; }
            public int suggestedRadius { get; set; }
            public string headerLocation { get; set; }
            public string headerFullLocation { get; set; }
            public string headerLocationGranularity { get; set; }
            public int totalResults { get; set; }
            public SuggestedBounds suggestedBounds { get; set; }
            public List<Group> groups { get; set; }
        }

        public class RootObject
        {
            public Meta meta { get; set; }
            public List<Notification> notifications { get; set; }
            public Response response { get; set; }
        }
    }
}
