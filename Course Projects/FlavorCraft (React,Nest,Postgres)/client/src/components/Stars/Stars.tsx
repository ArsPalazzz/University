import StarBorderOutlinedIcon from "@mui/icons-material/StarBorderOutlined";
import StarIcon from "@mui/icons-material/Star";
import StarHalfIcon from "@mui/icons-material/StarHalf";
import { Box, Typography } from "@mui/material";

const ShowStars = ({
  rating,
  rating_count,
}: {
  rating: number;
  rating_count?: number;
}) => {
  return (
    <Box sx={{ display: "flex", gap: 2 }}>
      <Box sx={{ display: "flex" }}>
        {new Array(5).fill(0).map((_, index) => {
          const starValue = index + 1;

          if (rating >= starValue) {
            // Полностью закрашенная звезда
            return <StarIcon sx={{ color: "gold" }} key={index} />;
          } else if (rating > starValue - 1 && rating < starValue) {
            // Частично закрашенная звезда
            return <StarHalfIcon sx={{ color: "gold" }} key={index} />;
          } else {
            // Пустая звезда
            return (
              <StarBorderOutlinedIcon sx={{ color: "gold" }} key={index} />
            );
          }
        })}
      </Box>
      {rating_count && <Typography>{rating_count}</Typography>}
    </Box>
  );
};

export default ShowStars;
