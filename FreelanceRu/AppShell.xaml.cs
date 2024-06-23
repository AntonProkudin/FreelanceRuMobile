using FreelanceRu.Pages;
using FreelanceRu.Pages.Popup;

namespace FreelanceRu
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("ListChatPage", typeof(ListChatPage));
            Routing.RegisterRoute("ChatPage", typeof(ChatPage));
            Routing.RegisterRoute("OrdersPage", typeof(OrdersPage));
            Routing.RegisterRoute("ProfilePage", typeof(ProfilePage));
            Routing.RegisterRoute("StockPage", typeof(StockPage));
            Routing.RegisterRoute("NewsPage", typeof(NewsPage));
            Routing.RegisterRoute("NewOrderPagePopup", typeof(NewOrderPagePopup));
            Routing.RegisterRoute("ChangeOrderPagePopup", typeof(ChangeOrderPagePopup));
            Routing.RegisterRoute("UserInfoPagePopup", typeof(UserInfoPagePopup));
        }
    }
}
