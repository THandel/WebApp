-- This query reads an XML file, parses it, and outputs its data to a SQL Table
-- The data is output to the XMLDB.mdf database rather than the lugh4 database
-- since I don't have bulkadmin rights on the server.

-- The data needs to be copied from the XMLDB to the server after the XML data has been added.

DECLARE @x xml -- Declare variable @x as xml

SELECT @x=M -- Select from XML file
FROM OPENROWSET (BULK /*FILE NAME AND PATH HERE*/'', SINGLE_BLOB) AS MarketData(M)

DECLARE @hdoc int -- Declare output 

EXEC sp_xml_preparedocument @hdoc OUTPUT, @x -- Execute stored procedure xml_preparedocument

INSERT INTO MarketData -- Insert data into table
SELECT * -- Select all data
FROM OPENXML (@hdoc, '/REPORT/REPORT_BODY/PAGE/DATAROW', 2) -- From the xml file, at the /REPORT/REPORT_BODY/PAGE/DATAROW level
WITH (
	num int '@num', -- Get value of num at /REPORT/REPORT_BODY/PAGE/ level
	TRADE_DATE nchar(20), -- Get value of Trade_Date 
	DELIVERY_DATE nchar(20), -- Get value of Delivery_Date
	DELIVERY_HOUR int, -- Get value of Delivery_Hour
	DELIVERY_INTERVAL int, -- Get value of Delivery_Interval
	RUN_TYPE nchar(5), -- Get Run_Type value 
	AGGREGATED_MSQ decimal(16, 4), -- Get aggregate_MSQ value to 4 decimal places
	SMP decimal(16, 2), -- Get SMP value to 2 decimal places
	CURRENCY_FLAG nchar(1) -- Get Currency_Flag value, 1 character (either E or P)
	)

EXEC sp_xml_removedocument @hdoc -- Execute stored procedure xml_removedocument to avoid resource leak