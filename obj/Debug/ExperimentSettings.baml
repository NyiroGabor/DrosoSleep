   M S B A M L   `   `   `  ����E  ADrosoSleep, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DrosoSleep
DrosoSleep  5   	   (    "DrosoSleep.ExperimentBasicSettings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DrosoSleep     5   	     � Title$  ExperimentBasicSettings��5   	   $��529.219��6)   $��598.4��6:    � WindowStartupLocation$ CenterScreen=�6H   .��5	      � ���	#FF7F8CA5.+�5
   
   �� $��Bin length:��6   $
��Left=�6&   $��	39,70,0,0q�6A   $	��Top=�6T   $��20(�6l   �� 5   
   $��Experiment settings��6   $
��Left=�6.   $��	161,0,0,0q�6I   $	��Top=�6\   $��30(�6t   �� 5   
   -   5         ��Name$ 
Bin_Length��5      $
��Left=�6&   $��23��6A   $��
152,79,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��120��6�   6�   �� 5   
   $,��&The number of minutes a bin counts as.��6   $
��Left=�6A   $��
39,102,0,0q�6\   $	��Top=�6p   �� 5   
   $��Sleep:��6   $
��Left=�6!   $��
311,70,0,0q�6<   $	��Top=�6P   $��20(�6h   �� 5   
   -   5        $ Sleep��5      $
��Left=�6!   $��23��6<   $��
378,79,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��169��6�   �� 5   
   $6��0The number of inactive bins that count
as sleep.��6   $
��Left=�6O   $��311,102,0,0q�6j   $	��Top=�6   �� 5   
   $��	Treshold:��6   $
��Left=�6$   $��
39,163,0,0q�6?   $	��Top=�6S   $��20(�6k   �� 5   
   -   5        $ Treshold��5      $
��Left=�6$   $��23��6?   $��138,172,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��134��6�   �� 5   
   $H��BInactivity treshold.
The highest value that counts as inactivity.��6   $
��Left=�6e   $��
39,195,0,0q�6�   $	��Top=�6�   �� 5   
   $��Dead:��6   $
��Left=�6    $��311,163,0,0q�6;   $	��Top=�6P   $��20(�6h   �� 5   
   -   5        $
 Dead��5      $
��Left=�6    $��23��6;   $��378,172,0,0q�6G   $
 Wrap=�6\   $	��Top=�6p   $	��169��6�   �� 5   
   $B��<The minimal activity per day before the fly
counts as dead.��6   $
��Left=�6_   $��311,195,0,0q�6z   $	��Top=�6�   �� 5   
   $��Exclude dead:��6   $
��Left=�6(   $��
39,258,0,0q�6C   $	��Top=�6W   $��20(�6o   �� 5   
   $����If activated the dead flies are excluded from
the experiment. If not activated the flies are
marked as dead on the days they were dead.��6   $
��Left=�6�   $��
39,290,0,0q�6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ Exclude_dead��5      $�� ��6)   $
��Left=�64   $��174,272,0,0q�6O   $	��Top=�6d   �� 5   
   $��Save settings:��6   $
��Left=�6)   $��311,258,0,0q�6D   $	��Top=�6Y   $��20(�6q   �� 5   
   $���~If activated the settings will be remembered
for the next experiment. If not activated the
settings will be set back to blank.��6   $
��Left=�6�   $��311,290,0,0q�6�   $	��Top=�6�   �� 5   
   -   5        $ Save_settings��5      $�� ��6*   $
��Left=�65   $��446,272,0,0q�6P   $	��Top=�6e   �� 5   
   -   5        $
��Save��5      $
��Left=�6    $��
39,431,0,0q�6;   $	��Top=�6O   $	��237��6g   $��41��6s   $��20(�6   6�   �� 5   
   -   5        $��Cancel��5      $
��Left=�6"   $��310,431,0,0q�6=   $	��Top=�6R   $	��237��6j   $��41��6v   $��20(�6�   6�   �� 5   
   $��Number of bins for a DAY:��6   $
��Left=�64   $��
39,352,0,0q�6O   $	��Top=�6c   �� 5    
   -	   5         ��Name$ Number_Of_Rows_In_A_Day��5       $�� ��61   $
��Left=�6<   $��183,352,0,0q�6W   $	��Top=�6l   $
��Bold"�6�   �� 5!   
   $!��Number of bins for an HOUR:��6   $
��Left=�66   $��
39,380,0,0q�6Q   $	��Top=�6e   �� 5"   
   -
   5        $ Number_Of_Rows_In_An_Hour��5"      $�� ��63   $
��Left=�6>   $��202,379,0,0q�6Y   $	��Top=�6n   $
��Bold"�6�   
���   �6�   �� 5#   
   -   5        $  Can_Hourly_Calculate_Error��5#      $�� ��64   $
��Left=�6?   $��
39,121,0,0q�6Z   $	��Top=�6n   $
��Bold"�6�   ���	#FF7900006�   5%      5&      