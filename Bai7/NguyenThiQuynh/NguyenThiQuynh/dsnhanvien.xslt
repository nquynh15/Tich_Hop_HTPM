<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="ds">
		<html>
			<body>
				<table border="1" width="100%" cellspacing="0">
					<tr>
						<th></th>
						<th>Mã nhân viên</th>
						<th>Họ tên</th>
						<th>Địa chỉ</th>
					</tr>
					<xsl:apply-templates select="nhanvien"/>
				</table>
			</body>
		</html>
    </xsl:template>
	<xsl:template match="nhanvien">
		<tr>
			<td></td>
			<td>
				<xsl:value-of select="@manv"/>
			</td>
			<td>
				<xsl:value-of select="hoten"/>
			</td>
			<td>
				<xsl:value-of select="diachi"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
