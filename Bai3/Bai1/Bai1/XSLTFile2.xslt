<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="congty">
		<html>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG 11-2009</h1>
				<xsl:apply-templates select="congty/donvi"/>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
