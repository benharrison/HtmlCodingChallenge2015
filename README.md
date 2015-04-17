# HtmlCodingChallenge2015

Your task is to develop a .NET 4 MVC website to visualize data from the provided .CSV file. 

Here is a sample:
ColumnIndex	ColumnOpacity	Box1	Box2	Box3	Box4	Box5	Box6	Box7	Box8	Box9	Box10	Box11	Box12
1	0.977	0.002	0.003	0.133	0.186	0.197	0.075	0.057	0.008	0.037	0.043	0.145	0.115
2	1	0	0	0.131	0.227	0.246	0.049	0.067	0	0	0.029	0.138	0.113

Here is a sample screenshot of what your visualization could look like:


Your goal is to create 115 equal-width columns based on the data.  Your whole visualization should fill 100% of browser Width and Height. 

Inside each column, draw 12 stacked boxes – one for each “Box1-Box12” value in the SQL database.  The value of each Box in the .CSV determines its height – 0.24 means that the box should take up 24% of the column height.  If you add up all Box1-Box12 values for the same column, you’ll see that they add up to about 1.0 (or 100%).  If the values do not add up to 100%, use your judgment on how to handle that.

In addition to drawing 12 boxes inside each column, please color them according to their Box number.  Box1 should be Red, Box2 should be Orange, et cetera.  The actual colors don’t matter – just make sure that Box1 is the same color in every column.

Since there are 115 columns, and 12 boxes in each, you’re drawing a lot of objects on the screen.  Your goal is to make your HTML drawing code as high-performance as possible, especially when the window is being resized.

Please support all major browsers.

Summary:

1. Read data from the SQL database
2. Visualize the “cells” on the web page based on the Box values in the database
3. Fill all available browser width and height
4. Finish it so it works correctly in one hour or less

If the project isn’t done in 55 minutes, please submit what you have so far.

Thanks! 
