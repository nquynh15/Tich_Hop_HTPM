<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="congty">
		<html>
			<head>
				<link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
			</head>
			<body>
				<h1 align="center">BẢNG LƯƠNG THÁNG 11-2009</h1>
				<xsl:for-each select="donvi">
					<h2>Mã đơn vị: <xsl:value-of select="@madv"/></h2>
					<h2>Tên đơn vị: <xsl:value-of select="tendv"/></h2>
					<h2>Điện thoại: <xsl:value-of select="dienthoai"/></h2>
					<h2 align="center">DANH SÁCH NHÂN VIÊN</h2>
					<table border="2" width="100%" cellspacing="0">
						<tr  class="tieude">
							<th>STT</th>
							<th>Mã NV</th>
							<th>Họ tên</th>
							<th>Ngày sinh</th>
							<th>Hệ số lương</th>
							<th>Lương</th>
						</tr>
						<xsl:for-each select="nhanvien">
							<tr>
								<td class="so"> <xsl:value-of select="position()"/> </td>
								<td class="chuoi">
									<xsl:value-of select="manv"/>
								</td>
								<td>
									<xsl:value-of select="hoten"/>
								</td>
								<td>
									<xsl:value-of select="ngaysinh"/>
								</td>
								<td class="so">
									<xsl:value-of select="hsluong"/>
								</td>
								<td class="so">
									<xsl:value-of select="hsluong*730000"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
					<h3 align="Right">THỦ TRƯỞNG ĐƠN VỊ</h3>

					<br/>
					<center>--------------------------------------------------------------------------------------------</center>
				</xsl:for-each>
			</body>
		</html>
    </xsl:template>
</xsl:stylesheet>
