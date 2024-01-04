import { Box, Grid, Typography } from "@mui/material";
import "./LobbyThemesContainer.scss";
import typography from "../../theme/typography.js";
import { LOBBY_TITLES } from "../../app/constants.js";
import LobbyThemeItem from "./LobbyThemeItem/LobbyThemeItem.jsx";

const imageUrl =
  "https://news.artnet.com/app/news-upload/2019/01/Cat-Photog-Feat-256x256.jpg";
const items = [
  { id: 1, url: imageUrl, title: "Спорт" },
  { id: 2, url: imageUrl, title: "Мистецтво" },
  { id: 3, url: imageUrl, title: "Машини" },
  { id: 4, url: imageUrl, title: "Домашні улюбленці" },
  { id: 5, url: imageUrl, title: "Аніме" },
  { id: 6, url: imageUrl, title: "Саморозвиток" },
  { id: 7, url: imageUrl, title: "Ігри" },
  { id: 8, url: imageUrl, title: "Мода" },
  { id: 9, url: imageUrl, title: "Хоббі" },
  { id: 10, url: imageUrl, title: "Подорожі" },
  { id: 11, url: imageUrl, title: "Шоубізнес" },
  { id: 12, url: imageUrl, title: "Кіно і серіали" },
];

const LobbyThemesContainer = () => {
  return (
    <Box className="lobby-themes">
      <Box className="lobby-themes__title">
        <Typography sx={{ ...typography.body1, fontWeight: "700" }}>
          {LOBBY_TITLES.POPULAR_THEMES}
        </Typography>
      </Box>
      <Grid container className="lobby-themes__container">
        {items.map((el) => (
          <LobbyThemeItem key={el.id} item={el} />
        ))}
      </Grid>
    </Box>
  );
};
export default LobbyThemesContainer;
