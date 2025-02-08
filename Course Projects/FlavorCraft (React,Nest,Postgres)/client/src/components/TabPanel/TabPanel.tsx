import React, { useLayoutEffect, useState } from "react";
import { Tabs, Tab, Box } from "@mui/material";
import { useLocation } from "react-router-dom";

// Компонент Tabs
interface ReusableTabsProps {
  children: React.ReactNode; // Вложенные компоненты
  labels: string[]; // Метки для вкладок
}

export const TabPanel = ({ children, labels }: ReusableTabsProps) => {
  const [activeTab, setActiveTab] = useState(0);
  const location = useLocation();

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setActiveTab(newValue);
  };

  useLayoutEffect(() => {
    const queryParams = new URLSearchParams(location.search);
    const tabValue = queryParams.get("tab");
    if (tabValue === "fav") setActiveTab(1);
  }, []);

  return (
    <Box sx={{ width: "100%" }}>
      {/* Заголовки табов */}
      <Tabs value={activeTab} onChange={handleChange} aria-label="tabs">
        {labels.map((label, index) => (
          <Tab key={index} label={label} />
        ))}
      </Tabs>

      {/* Отображение активного контента */}
      <Box sx={{ mt: 2 }}>{React.Children.toArray(children)[activeTab]}</Box>
    </Box>
  );
};
